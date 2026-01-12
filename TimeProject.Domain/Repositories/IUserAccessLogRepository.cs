using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IUserAccessLogRepository
{
    public IUserAccessLog Create(IUserAccessLog entity);
    public IUserAccessLog? GetLastAccessByUserId(int id);
    public IList<IUserAccessLog> GetLastAccessByUserIdList(IEnumerable<int> idList);
}