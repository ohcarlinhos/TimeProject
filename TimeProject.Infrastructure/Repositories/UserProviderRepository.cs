using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserProviderRepository(CustomDbContext db) : IUserProviderRepository
{
    public IUserProvider Create(IUserProvider entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        db.UserProviders.Add((UserProvider)entity);
        db.SaveChanges();
        return entity;
    }

    public bool Delete(int id)
    {
        var entity = FindByUserId(id);
        if (entity == null) return true;

        db.UserProviders.Remove((UserProvider)entity);
        db.SaveChanges();
        return true;
    }

    public IUserProvider? FindByUserId(int id)
    {
        return db.UserProviders.FirstOrDefault(i => i.UserId == id);
    }

    public IUserProvider? FindByUserProviderId(string provider, string id)
    {
        return db.UserProviders.FirstOrDefault(i => i.Provider == provider && i.ExternalId == id);
    }
}