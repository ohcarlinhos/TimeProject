using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.UseCases.TimerSession;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimerSession;

public class DeleteTimerSessionUseCase(
    ITimerSessionRepository repo,
    ITimePeriodRepository tpRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase) : IDeleteTimerSessionUseCase
{
    public async Task<ICustomResult<bool>> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = await repo.FindById(id, userId);

        if (entity == null)
            return result.SetError(TimerSessionMessageErrors.NotFound);

        await tpRepo.DeleteByList(entity.PeriodRecords!.ToList());
        var timeRecordId = entity.RecordId;

        await repo.Delete(entity);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(true);
    }
}