using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimePeriod;

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
        await syncTrMetaUseCase.Handle(timePeriod.RecordId);

        return result.SetData(data);
    }
}