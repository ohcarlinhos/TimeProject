using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.TimeRecord.UseCases;

public class DeleteTimeRecordUseCase(ITimeRecordRepository repo) : IDeleteTimeRecordUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(await repo.Delete(entity));
    }
}