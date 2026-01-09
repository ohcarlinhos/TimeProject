using Core.TimeMinute;
using Core.TimeMinute.UseCases;
using Core.TimeRecord.UseCases;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.TimeMinute.UseCases;

public class DeleteTimeMinuteUseCase(
    ITimeMinuteRepository repository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : IDeleteTimeMinuteUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();

        var timeMinute = await repository.FindById(id, userId);
        if (timeMinute == null) return result.SetError(TimeMinuteMessageErrors.NotFound);

        var data = await repository.Delete(timeMinute);
        await syncTrMetaUseCase.Handle(timeMinute.TimeRecordId);

        return result.SetData(data);
    }
}