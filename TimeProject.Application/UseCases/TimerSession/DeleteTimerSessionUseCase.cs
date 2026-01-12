using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.UseCases.Sessions;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Application.UseCases.TimerSession;

public class DeleteTimerSessionUseCase(
    ISessionRepository repo,
    IPeriodRepository tpRepo,
    ISyncRecordMetaUseCase syncRecordMetaUseCase) : IDeleteTimerSessionUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = (Session)repo.FindById(id, userId);

        if (entity == null)
            return result.SetError(TimerSessionMessageErrors.NotFound);

        tpRepo.DeleteByList(entity.PeriodRecords as IList<IPeriod>);
        var timeRecordId = entity.RecordId;

        repo.Delete(entity);
        syncRecordMetaUseCase.Handle(timeRecordId);

        return result.SetData(true);
    }
}