using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

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