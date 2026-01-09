using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity);
}