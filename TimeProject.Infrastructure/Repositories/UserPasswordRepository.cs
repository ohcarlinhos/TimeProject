using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserPasswordRepository(CustomDbContext db) : IUserPasswordRepository
{
    public bool Create(IUserPassword entity)
    {
        db.UserPasswords.Add((UserPassword)entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(IUserPassword entity)
    {
        db.UserPasswords.Update((UserPassword)entity);
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var entity = FindByUserId(id);
        if (entity == null) return true;

        db.UserPasswords.Remove((UserPassword)entity);
        db.SaveChanges();
        return true;
    }

    public IUserPassword? FindByUserId(int userId)
    {
        return db.UserPasswords.FirstOrDefault(i => i.UserId == userId);
    }
}