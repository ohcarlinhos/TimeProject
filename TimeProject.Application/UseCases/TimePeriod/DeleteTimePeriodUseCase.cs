using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimePeriod;

public class DeleteTimePeriodUseCase(IPeriodRecordRepository repo, ISyncTrMetaUseCase syncTrMetaUseCase)
    : IDeleteTimePeriodUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var timePeriod = repo.FindById(id, userId);

        if (timePeriod == null)
            return result.SetError(TimePeriodMessageErrors.NotFound);

        var data = repo.Delete(timePeriod);
        syncTrMetaUseCase.Handle(timePeriod.RecordId);

        return result.SetData(data);
    }
}