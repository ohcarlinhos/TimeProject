using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.CustomLog;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.CustomLog;

public class CreateUserAccessLogUseCase(IUserAccessLogRepository repository) : ICreateUserAccessLogUseCase
{
    public async Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity)
    {
        return new Result<UserAccessLogEntity>().SetData(await repository.Create(entity));
    }
}