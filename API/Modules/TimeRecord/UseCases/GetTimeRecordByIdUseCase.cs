using System.Security.Claims;
using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using API.Modules.TimeRecord.Repositories;
using Entities;
using Shared.General;
using Shared.General.Util;

namespace API.Modules.TimeRecord.UseCases;

public class GetTimeRecordByIdUseCase(ITimeRecordRepository repository) : IGetTimeRecordByIdUseCase
{
    public async Task<Result<TimeRecordEntity>> Handle(int id, ClaimsPrincipal user)
    {
        var result = new Result<TimeRecordEntity>();
        var timeRecord = await repository.FindById(id, UserClaims.Id(user));
        return timeRecord != null
            ? result.SetData(timeRecord)
            : result.SetError(TimeRecordErrors.NotFound);
    }
}