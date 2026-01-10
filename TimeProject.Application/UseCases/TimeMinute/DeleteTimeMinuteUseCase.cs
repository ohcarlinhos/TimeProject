using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeMinute;

public class DeleteTimeMinuteUseCase(
    ITimeMinuteRepository repository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : IDeleteTimeMinuteUseCase
{
    public async Task<ICustomResult<bool>> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();

        var timeMinute = await repository.FindById(id, userId);
        if (timeMinute == null) return result.SetError(TimeMinuteMessageErrors.NotFound);

        var data = await repository.Delete(timeMinute);
        await syncTrMetaUseCase.Handle(timeMinute.RecordId);

        return result.SetData(data);
    }
}