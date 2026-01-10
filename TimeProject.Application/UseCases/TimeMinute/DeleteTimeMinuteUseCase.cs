using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeMinute;

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