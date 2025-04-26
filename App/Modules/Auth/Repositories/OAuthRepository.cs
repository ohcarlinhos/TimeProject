using App.Database;
using Core.Auth.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Auth.Repositories
{
    public class OAuthRepository(ProjectContext dbContext) : IOAuthRepository
    {
        public async Task<OAuthEntity> Create(OAuthEntity entity)
        {
            var now = DateTime.Now.ToUniversalTime();
            entity.CreatedAt = now;
            entity.UpdatedAt = now;

            dbContext.OAuths.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await FindByUserId(id);
            if (entity == null) return true;

            dbContext.OAuths.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OAuthEntity?> FindByUserId(int id)
        {
            return await dbContext.OAuths.FirstOrDefaultAsync(i => i.UserId == id);
        }

        public async Task<OAuthEntity?> FindByUserProviderId(string provider, string id)
        {
            return await dbContext.OAuths.FirstOrDefaultAsync(i => i.Provider == provider && i.UserProviderId == id);
        }
    }
}