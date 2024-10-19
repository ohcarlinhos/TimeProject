using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.TimeRecord.UseCases;

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