using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface IUserAccessLogRepository
{
    public Task<UserAccessLogEntity> Create(UserAccessLogEntity entity);
    public Task<UserAccessLogEntity?> GetLastAccessByUserId(int id);
    public List<UserAccessLogEntity> GetLastAccessByUserIdList(IEnumerable<int> idList);
}