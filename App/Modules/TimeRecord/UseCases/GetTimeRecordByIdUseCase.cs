using System.Security.Claims;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using App.Infrastructure.Errors;
using Entities;
using Shared.General;

namespace App.Modules.TimeRecord.UseCases;

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