using Core.Loogs.Repositories;
using Core.Loogs.UserCases;
using Entities;
using Shared.General;

namespace TimeProject.Api.Modules.Loogs.UseCases;

public class CreateUserAccessLog(IUserAccessLogRepository repository) : ICreateUserAccessLog
{
    public async Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity)
    {
        return new Result<UserAccessLogEntity>().SetData(await repository.Create(entity));
    }
}