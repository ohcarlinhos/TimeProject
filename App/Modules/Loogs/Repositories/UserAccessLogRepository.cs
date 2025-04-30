using App.Database;
using Core.Loogs.Repositories;
using Entities;

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
    }
}