using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;
using TimeProject.Domain.TimeRecord.Repositories;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordHistoryUseCase(
    ITimeRecordHistoryRepository repository,
    IUserRepository userRepository,
    ITimeRecordMapDataUtil mapDataUtil) : IGetTimeRecordHistoryUseCase
{
    public async Task<ICustomResult<IPagination<TimeRecordHistoryDayOutDto>>> Handle(
        int timeRecordId,
        int userId,
        PaginationQuery paginationQuery
    )
    {
        var user = await userRepository.FindById(userId);
        if (user == null)
        {
            return new CustomResult<IPagination<TimeRecordHistoryDayOutDto>>()
                .SetError(UserMessageErrors.NotFound);
        }

        // É passado um int referente ao UTC entre -12 e 13, para que consigamos saber as datas do UTC do usuário.
        var distinctDates = await repository.GetDistinctDates(timeRecordId, userId, user.Utc);

        var dates = distinctDates
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage);

        var historyDays = new List<TimeRecordHistoryDay>();

        foreach (var dateItem in dates)
        {
            // initDate pega a data que já subtraimos a diferênça de utc e somamos novamente para fazer a busca correnta.
            var initDate = dateItem.AddHours(user.Utc * -1);
            var endDate = initDate.AddDays(1);

            var tpList = await repository.GetTimePeriodsWithoutTimerSession(timeRecordId, userId, initDate, endDate);
            var tsList = await repository.GetTimerSessions(timeRecordId, userId, initDate, endDate);
            var tmList = await repository.GetTimeMinutes(timeRecordId, userId, initDate, endDate);

            if (tpList.Count == 0 && tsList.Count == 0 && tmList.Count == 0) continue;

            historyDays.Add(new TimeRecordHistoryDay
            {
                Date = initDate,
                InitDate = initDate,
                EndDate = endDate,
                TimePeriods = tpList,
                TimeMinutes = tmList,
                TimerSessions = tsList
            });
        }

        return new CustomResult<IPagination<TimeRecordHistoryDayOutDto>>
        {
            Data = Pagination<TimeRecordHistoryDayOutDto>
                .Handle(mapDataUtil.Handle(historyDays), paginationQuery, distinctDates.Count)
        };
    }
}