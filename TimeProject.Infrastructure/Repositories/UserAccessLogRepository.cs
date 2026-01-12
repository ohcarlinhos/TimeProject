using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserAccessLogRepository(CustomDbContext db) : IUserAccessLogRepository
{
    public IUserAccessLog Create(IUserAccessLog entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.AccessAt = now;

        var accessLog = (UserAccessLog)entity;
        db.UserAccessLogs.Add(accessLog);
        db.SaveChanges();
        return accessLog;
    }

    public IUserAccessLog? GetLastAccessByUserId(int id)
    {
        var maxAccessAt = db.UserAccessLogs
            .Where(e => e.UserId == id)
            .Max(e => e.AccessAt);

        return db.UserAccessLogs.FirstOrDefault(e => e.UserId == id && e.AccessAt == maxAccessAt);
    }

    public IList<IUserAccessLog> GetLastAccessByUserIdList(IEnumerable<int> idList)
    {
        var list = new List<IUserAccessLog>();

        foreach (var id in idList)
        {
            DateTime? maxAccessAt = db.UserAccessLogs.Any(e => e.UserId == id)
                ? db.UserAccessLogs.Where(e => e.UserId == id).Max(e => e.AccessAt)
                : null;

            var lastAccessByUserId = db.UserAccessLogs
                .FirstOrDefault(e => e.UserId == id && e.AccessAt == maxAccessAt);

            if (lastAccessByUserId is not null)
                list.Add(lastAccessByUserId);
        }

        return list;
    }
}