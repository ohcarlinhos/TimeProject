using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class OAuthRepository(CustomDbContext db) : IOAuthRepository
{
    public IOAuth Create(IOAuth entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var iOAuth = (OAuth)entity;
        iOAuth.CreatedAt = now;
        iOAuth.UpdatedAt = now;

        db.OAuths.Add(iOAuth);
        db.SaveChanges();
        return iOAuth;
    }

    public bool Delete(int id)
    {
        var entity = FindByUserId(id);
        if (entity == null) return true;

        db.OAuths.Remove((OAuth)entity);
        db.SaveChanges();
        return true;
    }

    public IOAuth? FindByUserId(int id)
    {
        return db.OAuths.FirstOrDefault(i => i.UserId == id);
    }

    public IOAuth? FindByUserProviderId(string provider, string id)
    {
        return db.OAuths.FirstOrDefault(i => i.Provider == provider && i.UserProviderId == id);
    }
}