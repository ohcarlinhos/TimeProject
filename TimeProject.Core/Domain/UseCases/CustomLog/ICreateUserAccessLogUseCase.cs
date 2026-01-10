using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity);
}