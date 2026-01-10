using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.CustomLog;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.CustomLog;

public class CreateUserAccessLogUseCase(IUserAccessLogRepository repository) : ICreateUserAccessLogUseCase
{
    public async Task<Result<UserAccessLog>> Handle(UserAccessLog entity)
    {
        return new Result<UserAccessLog>().SetData(await repository.Create(entity));
    }
}