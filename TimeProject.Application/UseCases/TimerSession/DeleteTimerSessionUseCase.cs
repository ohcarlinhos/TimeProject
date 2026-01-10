using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.UseCases.TimerSession;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimerSession;

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

        await repo.Delete(entity);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(true);
    }
}