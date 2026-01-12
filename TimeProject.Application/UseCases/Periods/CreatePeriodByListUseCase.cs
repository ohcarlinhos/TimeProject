using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Records;

namespace TimeProject.Application.UseCases.Periods;

public class CreatePeriodByListUseCase(
    IPeriodRepository repository,
    ISessionRepository sessionRepository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase,
    IPeriodValidateUtil periodValidateUtil
) : ICreatePeriodByListUseCase
{
    public ICustomResult<IList<IPeriod>> Handle(IPeriodListDto dto, int recordId, int userId)
    {
        var result = new CustomResult<IList<IPeriod>>();
        List<Period> list = [];

        foreach (var timePeriod in dto.Periods)
        {
            periodValidateUtil.ValidateStartAndEnd(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            if (periodValidateUtil.HasMinSize(timePeriod))
                list.Add(new Period
                {
                    UserId = userId,
                    RecordId = recordId,
                    Start = timePeriod.Start,
                    End = timePeriod.End
                });
        }

        if (result.HasError) return result;
        if (list.Count == 0) return result.SetData([]);

        var timerSession = sessionRepository.Create(new Session()
            { RecordId = recordId, UserId = userId, Type = dto.Type, From = dto.From }
        );

        list.ForEach(i => { i.TimerSessionId = timerSession.Id; });

        var data = repository.CreateByList(list as IList<IPeriod>);
        syncRecordMetaUseCase.Handle(recordId);

        return result.SetData(data);
    }
}