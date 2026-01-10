using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class DeleteTimeRecordUseCase(ITimeRecordRepository repo) : IDeleteTimeRecordUseCase
{
    public async Task<ICustomResult<bool>> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(await repo.Delete(entity));
    }
}