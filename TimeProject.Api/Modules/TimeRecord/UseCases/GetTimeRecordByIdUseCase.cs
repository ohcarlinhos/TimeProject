using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Entities;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.TimeRecord.UseCases;

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