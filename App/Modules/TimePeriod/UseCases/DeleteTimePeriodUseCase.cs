using Core.TimePeriod;
using Core.TimePeriod.UseCases;
using Core.TimeRecord.UseCases;
using App.Infrastructure.Errors;
using Shared.General;

namespace App.Modules.TimePeriod.UseCases;

public class DeleteTimePeriodUseCase(ITimePeriodRepository repo, ISyncTrMetaUseCase syncTrMetaUseCase)
    : IDeleteTimePeriodUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var timePeriod = await repo.FindById(id, userId);

        if (timePeriod == null)
            return result.SetError(TimePeriodMessageErrors.NotFound);

        var data = await repo.Delete(timePeriod);
        await syncTrMetaUseCase.Handle(timePeriod.TimeRecordId);

        return result.SetData(data);
    }
}