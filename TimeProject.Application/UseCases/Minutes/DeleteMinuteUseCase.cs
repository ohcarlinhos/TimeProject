using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Minutes;

public class DeleteMinuteUseCase(
    IMinuteRepository repository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
) : IDeleteMinuteUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();

        var timeMinute = repository.FindById(id, userId);
        if (timeMinute == null) return result.SetError(TimeMinuteMessageErrors.NotFound);

        var data = repository.Delete(timeMinute);
        syncRecordMetaUseCase.Handle(timeMinute.RecordId);

        return result.SetData(data);
    }
}