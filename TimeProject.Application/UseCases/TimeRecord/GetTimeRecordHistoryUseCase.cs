using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Record;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordHistoryUseCase(
    IRecordHistoryRepository repository,
    IUserRepository userRepository,
    ITimeRecordMapDataUtil mapDataUtil) : IGetTimeRecordHistoryUseCase
{
    public ICustomResult<IPagination<IRecordHistoryDayOutDto>> Handle(
        int timeRecordId,
        int userId,
        PaginationQuery paginationQuery
    )
    {
        var user = userRepository.FindById(userId);
        if (user == null)
        {
            return new CustomResult<IPagination<IRecordHistoryDayOutDto>>().SetError(UserMessageErrors.NotFound);
        }

        // É passado um int referente ao UTC entre -12 e 13, para que consigamos saber as datas do UTC do usuário.
        var distinctDates = repository.GetDistinctDates(timeRecordId, userId, user.Utc);

        var dates = distinctDates
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage);

        var historyDays = new List<RecordHistoryDay>();

        foreach (var dateItem in dates)
        {
            // initDate pega a data que já subtraimos a diferênça de utc e somamos novamente para fazer a busca correnta.
            var initDate = dateItem.AddHours(user.Utc * -1);
            var endDate = initDate.AddDays(1);

            var tpList = repository.GetTimePeriodsWithoutTimerSession(timeRecordId, userId, initDate, endDate);
            var tsList = repository.GetTimerSessions(timeRecordId, userId, initDate, endDate);
            var tmList = repository.GetTimeMinutes(timeRecordId, userId, initDate, endDate);

            if (tpList.Count == 0 && tsList.Count == 0 && tmList.Count == 0) continue;

            historyDays.Add(new RecordHistoryDay
            {
                Date = initDate,
                InitDate = initDate,
                EndDate = endDate,
                Periods = tpList,
                Minutes = tmList,
                Sessions = tsList
            });
        }

        return new CustomResult<IPagination<IRecordHistoryDayOutDto>>
        {
            Data = Pagination<IRecordHistoryDayOutDto>
                .Handle(mapDataUtil.Handle(historyDays), paginationQuery, distinctDates.Count)
        };
    }
}