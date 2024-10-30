using Core.TimePeriod;
using Core.TimeRecord.UseCases;
using Core.TimerSession;
using Core.TimerSession.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.TimerSession.UseCases;

public class DeleteTimerSessionUseCase(
    ITimerSessionRepository repo,
    ITimePeriodRepository tpRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase) : IDeleteTimerSessionUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var entity = await repo.FindById(id, userId);

        if (entity == null)
            return result.SetError(TimerSessionMessageErrors.NotFound);

        await tpRepo.DeleteByList(entity.TimePeriods!.ToList());
        var timeRecordId = entity.TimeRecordId;

        var data = await repo.Delete(entity);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(true);
    }
}