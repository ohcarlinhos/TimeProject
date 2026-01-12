using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Periods;

public class DeletePeriodUseCase(IPeriodRepository repository, ISyncRecordMetaUseCase syncRecordMetaUseCase)
    : IDeletePeriodUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var timePeriod = repository.FindById(id, userId);

        if (timePeriod == null)
            return result.SetError(TimePeriodMessageErrors.NotFound);

        var data = repository.Delete(timePeriod);
        syncRecordMetaUseCase.Handle(timePeriod.RecordId);

        return result.SetData(data);
    }
}