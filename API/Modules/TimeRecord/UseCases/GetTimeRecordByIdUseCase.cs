using System.Security.Claims;
using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Entities;
using Shared.General;

namespace API.Modules.TimeRecord.UseCases;

public class GetTimeRecordByIdUseCase(ITimeRecordRepository repo) : IGetTimeRecordByIdUseCase
{
    public async Task<Result<TimeRecordEntity>> Handle(int id,  int userId)
    {
        var result = new Result<TimeRecordEntity>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(entity);
    }
}