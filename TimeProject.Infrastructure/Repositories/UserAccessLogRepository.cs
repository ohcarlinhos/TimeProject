using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserAccessLogRepository(ProjectContext dbContext) : IUserAccessLogRepository
{
    public async Task<UserAccessLog> Create(UserAccessLog entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.AccessAt = now;

        dbContext.UserAccessLogs.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public Task<UserAccessLog?> GetLastAccessByUserId(int id)
    {
        var maxAccessAt = dbContext.UserAccessLogs
            .Where(e => e.UserId == id)
            .Max(e => e.AccessAt);

        return dbContext.UserAccessLogs.Where(e => e.UserId == id && e.AccessAt == maxAccessAt)
            .FirstOrDefaultAsync();
    }

    public List<UserAccessLog> GetLastAccessByUserIdList(IEnumerable<int> idList)
    {
        var list = new List<UserAccessLog>();

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