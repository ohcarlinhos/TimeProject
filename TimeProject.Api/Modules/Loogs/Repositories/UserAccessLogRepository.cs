using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;

namespace TimeProject.Api.Modules.Loogs.Repositories;

public class UserAccessLogRepository(ProjectContext dbContext) : IUserAccessLogRepository
{
    public async Task<UserAccessLogEntity> Create(UserAccessLogEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.AccessAt = now;

        dbContext.UserAccessLogs.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public Task<UserAccessLogEntity?> GetLastAccessByUserId(int id)
    {
        var maxAccessAt = dbContext.UserAccessLogs
            .Where(e => e.UserId == id)
            .Max(e => e.AccessAt);

        return dbContext.UserAccessLogs.Where(e => e.UserId == id && e.AccessAt == maxAccessAt)
            .FirstOrDefaultAsync();
    }

    public List<UserAccessLogEntity> GetLastAccessByUserIdList(IEnumerable<int> idList)
    {
        var list = new List<UserAccessLogEntity>();

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