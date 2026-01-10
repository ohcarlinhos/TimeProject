using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IUserAccessLogRepository
{
    public Task<UserAccessLog> Create(UserAccessLog entity);
    public Task<UserAccessLog?> GetLastAccessByUserId(int id);
    public List<UserAccessLog> GetLastAccessByUserIdList(IEnumerable<int> idList);
}