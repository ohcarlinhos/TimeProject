using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimePeriod;

public class CreateTimePeriodByListUseCase(
    ITimePeriodRepository repo,
    ITimerSessionRepository timerSessionRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : ICreateTimePeriodByListUseCase
{
    public async Task<Result<List<TimePeriodEntity>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId)
    {
        var result = new Result<List<TimePeriodEntity>>();
        List<TimePeriodEntity> list = [];

        foreach (var timePeriod in dto.TimePeriods)
        {
            timePeriodValidateUtil.ValidateStartAndEnd(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            if (timePeriodValidateUtil.HasMinSize(timePeriod))
                list.Add(new TimePeriodEntity
                {
                    UserId = userId,
                    TimeRecordId = timeRecordId,
                    Start = timePeriod.Start,
                    End = timePeriod.End
                });
        }

        if (result.HasError) return result;
        if (list.Count == 0) return result.SetData([]);

        var timerSession = await timerSessionRepo.Create(new TimerSessionEntity
            { TimeRecordId = timeRecordId, UserId = userId, Type = dto.Type, From = dto.From }
        );

        list.ForEach(i => { i.TimerSessionId = timerSession.Id; });

        var data = await repo.CreateByList(list);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}