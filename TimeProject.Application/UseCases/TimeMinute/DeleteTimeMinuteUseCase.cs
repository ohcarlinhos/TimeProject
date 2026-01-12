using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeMinute;

public class DeleteTimeMinuteUseCase(
    IMinuteRecordRepository recordRepository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : IDeleteTimeMinuteUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();

        var timeMinute = recordRepository.FindById(id, userId);
        if (timeMinute == null) return result.SetError(TimeMinuteMessageErrors.NotFound);

        var data = recordRepository.Delete(timeMinute);
        syncTrMetaUseCase.Handle(timeMinute.RecordId);

        return result.SetData(data);
    }
}