using System.Security.Claims;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Core.TimeRecord.Utils;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimeRecord.UseCases;

public class GetTimeRecordHistoryUseCase(
    ITimeRecordHistoryRepository repo,
    ITimeRecordMapDataUtil mapDataUtil) : IGetTimeRecordHistoryUseCase
{
    public async Task<Result<Pagination<TimeRecordHistoryDayMap>>> Handle(
        int timeRecordId,
        int userId,
        PaginationQuery paginationQuery
    )
    {
        var distinctDates = await repo.GetDistinctDates(timeRecordId, userId, -3);

        var dates = distinctDates
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage);

        var historyDays = new List<TimeRecordHistoryDay>();

        foreach (var dateItem in dates)
        {
            var initDate = dateItem.AddHours(3);
            var endDate = initDate.AddDays(1);

            var tpList = await repo.GetTimePeriodsWithoutTimerSession(timeRecordId, userId, initDate, endDate);
            var tsList = await repo.GetTimerSessions(timeRecordId, userId, initDate, endDate);

            if (tpList.Count == 0 && tsList.Count == 0) continue;

            historyDays.Add(new TimeRecordHistoryDay
            {
                Date = initDate,
                InitDate = initDate,
                EndDate = endDate,
                TimePeriods = tpList,
                TimerSessions = tsList
            });
        }

        return new Result<Pagination<TimeRecordHistoryDayMap>>
        {
            Data = Pagination<TimeRecordHistoryDayMap>
                .Handle(mapDataUtil.Handle(historyDays), paginationQuery, distinctDates.Count)
        };
    }
}