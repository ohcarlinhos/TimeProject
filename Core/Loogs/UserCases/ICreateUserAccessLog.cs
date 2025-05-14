using Entities;
using Shared.General;

namespace Core.Loogs.UserCases;

public interface ICreateUserAccessLog
{
    Task<Result<UserAccessLogEntity>> Handle(UserAccessLogEntity entity);
}