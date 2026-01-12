using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserAccessLogRepository(ProjectContext dbContext) : IUserAccessLogRepository
{
    public IUserAccessLog Create(IUserAccessLog entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.AccessAt = now;

        var accessLog = (UserAccessLog)entity;
        dbContext.UserAccessLogs.Add(accessLog);
        dbContext.SaveChanges();
        return accessLog;
    }

    public IUserAccessLog? GetLastAccessByUserId(int id)
    {
        var maxAccessAt = dbContext.UserAccessLogs
            .Where(e => e.UserId == id)
            .Max(e => e.AccessAt);

        return dbContext.UserAccessLogs.FirstOrDefault(e => e.UserId == id && e.AccessAt == maxAccessAt);
    }

    public IList<IUserAccessLog> GetLastAccessByUserIdList(IEnumerable<int> idList)
    {
        var list = new List<IUserAccessLog>();

        foreach (var id in idList)
        {
            DateTime? maxAccessAt = dbContext.UserAccessLogs.Any(e => e.UserId == id)
                ? dbContext.UserAccessLogs.Where(e => e.UserId == id).Max(e => e.AccessAt)
                : null;

            var lastAccessByUserId = dbContext.UserAccessLogs
                .FirstOrDefault(e => e.UserId == id && e.AccessAt == maxAccessAt);

            if (lastAccessByUserId is not null)
                list.Add(lastAccessByUserId);
        }

        return list;
    }
}