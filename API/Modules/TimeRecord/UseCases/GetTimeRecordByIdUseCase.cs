using System.Security.Claims;
using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Entities;
using Shared.General;
using Shared.General.Util;

namespace API.Modules.TimeRecord.UseCases;

public class GetTimeRecordByIdUseCase(ITimeRecordRepository repo) : IGetTimeRecordByIdUseCase
{
    public async Task<Result<TimeRecordEntity>> Handle(int id, ClaimsPrincipal user)
    {
        var result = new Result<TimeRecordEntity>();
        var entity = await repo.FindById(id, UserClaims.Id(user));

        return entity == null
            ? result.SetError(TimeRecordErrors.NotFound)
            : result.SetData(entity);
    }
}