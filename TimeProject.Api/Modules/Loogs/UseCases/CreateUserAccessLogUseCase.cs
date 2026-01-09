using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.CustomLog;

namespace TimeProject.Api.Modules.Loogs.UseCases;

public class CreateUserAccessLogUseCase(IUserAccessLogRepository repository) : ICreateUserAccessLogUseCase
{
    public async Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity)
    {
        return new Result<UserAccessLogEntity>().SetData(await repository.Create(entity));
    }
}