using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    Task<Result<UserAccessLog>> Handle(UserAccessLog entity);
}