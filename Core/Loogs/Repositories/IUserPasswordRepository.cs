using Entities;

namespace Core.Loogs.Repositories;

public interface IUserAccessLogRepository
{
    public Task<UserAccessLogEntity> Create(UserAccessLogEntity entity);
}