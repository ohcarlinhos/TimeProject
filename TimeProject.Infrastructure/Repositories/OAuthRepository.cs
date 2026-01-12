using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class OAuthRepository(ProjectContext dbContext) : IOAuthRepository
{
    public IOAuth Create(IOAuth entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var iOAuth = (OAuth)entity;
        iOAuth.CreatedAt = now;
        iOAuth.UpdatedAt = now;

        dbContext.OAuths.Add(iOAuth);
        dbContext.SaveChanges();
        return iOAuth;
    }

    public bool Delete(int id)
    {
        var entity = FindByUserId(id);
        if (entity == null) return true;

        dbContext.OAuths.Remove((OAuth)entity);
        dbContext.SaveChanges();
        return true;
    }

    public IOAuth? FindByUserId(int id)
    {
        return dbContext.OAuths.FirstOrDefault(i => i.UserId == id);
    }

    public IOAuth? FindByUserProviderId(string provider, string id)
    {
        return dbContext.OAuths.FirstOrDefault(i => i.Provider == provider && i.UserProviderId == id);
    }
}