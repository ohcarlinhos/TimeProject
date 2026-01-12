using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Record;

namespace TimeProject.Application.UseCases.TimePeriod;

public class CreateTimePeriodByListUseCase(
    IPeriodRecordRepository repo,
    ITimerSessionRepository timerSessionRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : ICreateTimePeriodByListUseCase
{
    public ICustomResult<IList<IPeriod>> Handle(IPeriodListDto dto, int timeRecordId, int userId)
    {
        var result = new CustomResult<IList<IPeriod>>();
        List<Period> list = [];

        foreach (var timePeriod in dto.Periods)
        {
            timePeriodValidateUtil.ValidateStartAndEnd(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            if (timePeriodValidateUtil.HasMinSize(timePeriod))
                list.Add(new Period
                {
                    UserId = userId,
                    RecordId = timeRecordId,
                    Start = timePeriod.Start,
                    End = timePeriod.End
                });
        }

        if (result.HasError) return result;
        if (list.Count == 0) return result.SetData([]);

        var timerSession = timerSessionRepo.Create(new Session()
            { RecordId = timeRecordId, UserId = userId, Type = dto.Type, From = dto.From }
        );

        list.ForEach(i => { i.TimerSessionId = timerSession.Id; });

        var data = repo.CreateByList(list as IList<IPeriod>);
        syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}