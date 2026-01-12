using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeMinute;

public class DeleteTimeMinuteUseCase(
    IMinuteRepository repository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
) : IDeleteTimeMinuteUseCase
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