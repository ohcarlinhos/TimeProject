using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordByIdUseCase(ITimeRecordRepository repo) : IGetTimeRecordByIdUseCase
{
    public async Task<Result<TimeRecordEntity>> Handle(int id, int userId)
    {
        var result = new Result<TimeRecordEntity>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(entity);
    }
}