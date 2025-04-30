using Entities;
using Shared.General;

namespace Core.Logs.UserCases;

public interface ICreateUserAccessLog
{
    Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity);
}