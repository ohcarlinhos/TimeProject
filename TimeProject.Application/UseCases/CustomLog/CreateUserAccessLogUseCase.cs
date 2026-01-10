using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.CustomLog;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.CustomLog;

public class CreateUserAccessLogUseCase(IUserAccessLogRepository repository) : ICreateUserAccessLogUseCase
{
    public async Task<ICustomResult<UserAccessLog>> Handle(UserAccessLog entity)
    {
        return new CustomResult<UserAccessLog>().SetData(await repository.Create(entity));
    }
}