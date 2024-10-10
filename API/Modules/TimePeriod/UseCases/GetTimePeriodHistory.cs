using System.Security.Claims;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimePeriod.Util;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public class GetTimePeriodHistory(
    ITimePeriodHistoryRepository repo,
    ITimePeriodMapDataUtil mapDataUtil) : IGetTimePeriodHistory
{
    public async Task<Result<Pagination<HistoryPeriodDayMap>>> Handle(
        int timeRecordId,
        ClaimsPrincipal user,
        PaginationQuery paginationQuery
    )
    {
        var userId = UserClaims.Id(user);
        var distinctDates = await repo.GetDistinctDates(timeRecordId, userId, -3);
        
        var dates = distinctDates
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage);

        var historyDays = new List<HistoryPeriodDay>();

        foreach (var dateItem in dates)
        {
            var initDate = dateItem.AddHours(3);
            var endDate = initDate.AddDays(1);

            var tpList = await repo.GetTimePeriodsWithoutTimerSession(timeRecordId, userId, initDate, endDate);
            var tsList = await repo.GetTimerSessions(timeRecordId, userId, initDate, endDate);

            if (tpList.Count == 0 && tsList.Count == 0) continue;

            historyDays.Add(new HistoryPeriodDay
            {
                Date = initDate,
                InitDate = initDate,
                EndDate = endDate,
                TimePeriods = tpList,
                TimerSessions = tsList
            });
        }

        return new Result<Pagination<HistoryPeriodDayMap>>
        {
            Data = Pagination<HistoryPeriodDayMap>
                .Handle(mapDataUtil.Handle(historyDays), paginationQuery, distinctDates.Count)
        };
    }
}