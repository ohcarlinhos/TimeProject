using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord;

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