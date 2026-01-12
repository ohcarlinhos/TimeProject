using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
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
        var period = repository.FindById(id, userId);

        if (period == null)
            return result.SetError(PeriodMessageErrors.NotFound);

        var data = repository.Delete(period);
        syncRecordMetaUseCase.Handle(period.RecordId);

        return result.SetData(data);
    }
}