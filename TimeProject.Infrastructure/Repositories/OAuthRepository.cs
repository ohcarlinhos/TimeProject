using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class OAuthRepository(ProjectContext dbContext) : IOAuthRepository
{
    public async Task<IOAuth> Create(IOAuth entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var iOAuth = (OAuth)entity;
        iOAuth.CreatedAt = now;
        iOAuth.UpdatedAt = now;

        dbContext.OAuths.Add(iOAuth);
        await dbContext.SaveChangesAsync();
        return iOAuth;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await FindByUserId(id);
        if (entity == null) return true;

        dbContext.OAuths.Remove((OAuth)entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IOAuth?> FindByUserId(int id)
    {
        return await dbContext.OAuths.FirstOrDefaultAsync(i => i.UserId == id);
    }

    public async Task<IOAuth?> FindByUserProviderId(string provider, string id)
    {
        return await dbContext.OAuths.FirstOrDefaultAsync(i => i.Provider == provider && i.UserProviderId == id);
    }
}