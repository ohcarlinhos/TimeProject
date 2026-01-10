using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity);
}