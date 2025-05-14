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
            return dbContext.UserAccessLogs.FirstOrDefaultAsync(e => e.UserId == id);
        }

        public List<UserAccessLogEntity> GetLastAccessByUserIdList(IEnumerable<int> idList)
        {
            return dbContext.UserAccessLogs
                .Where(e => idList.Contains(e.UserId))
                .ToList();
        }
    }
}