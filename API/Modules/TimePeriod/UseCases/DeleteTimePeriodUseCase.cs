using API.Core.TimePeriod;
using API.Core.TimePeriod.UseCases;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.TimePeriod.UseCases;

public class DeleteTimePeriodUseCase(ITimePeriodRepository repo, ISyncTrMetaUseCase syncTrMetaUseCase)
    : IDeleteTimePeriodUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var timePeriod = await repo.FindById(id, userId);

        if (timePeriod == null)
            return result.SetError(TimePeriodErrors.NotFound);

        var data = await repo.Delete(timePeriod);
        await syncTrMetaUseCase.Handle(timePeriod.TimeRecordId);

        return result.SetData(data);
    }
}