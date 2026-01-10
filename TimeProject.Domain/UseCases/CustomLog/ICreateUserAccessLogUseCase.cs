using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    Task<ICustomResult<UserAccessLog>> Handle(UserAccessLog entity);
}