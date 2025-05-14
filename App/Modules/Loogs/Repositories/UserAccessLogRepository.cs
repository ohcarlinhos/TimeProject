using App.Database;
using Core.Loogs.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Loogs.Repositories
{
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
                var maxAccessAt = dbContext.UserAccessLogs
                    .Where(e => e.UserId == id)
                    .Max(e => e.AccessAt);

                var lastAccessByUserId = dbContext.UserAccessLogs
                    .FirstOrDefault(e => e.UserId == id && e.AccessAt == maxAccessAt);

                if (lastAccessByUserId is not null)
                    list.Add(lastAccessByUserId);
            }

            return list;
        }
    }
}