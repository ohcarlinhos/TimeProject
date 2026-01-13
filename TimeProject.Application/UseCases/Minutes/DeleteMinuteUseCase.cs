using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;

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
        if (timeMinute == null) return result.SetError(MinuteMessageErrors.NotFound);

        var data = repository.Delete(timeMinute);
        syncRecordMetaUseCase.Handle(timeMinute.RecordId);

        return result.SetData(data);
    }
}