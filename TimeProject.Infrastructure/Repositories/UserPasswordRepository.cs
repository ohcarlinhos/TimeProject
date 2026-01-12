using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserPasswordRepository(ProjectContext dbContext) : IUserPasswordRepository
{
    public bool Create(IUserPassword entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        var userPassword = (UserPassword)entity;
        userPassword.CreatedAt = now;
        userPassword.UpdatedAt = now;

        dbContext.UserPasswords.Add(userPassword);
        dbContext.SaveChanges();
        return true;
    }

    public bool Update(IUserPassword entity)
    {
        var userPassword = (UserPassword)entity;
        userPassword.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.UserPasswords.Update(userPassword);
        dbContext.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var entity = FindByUserId(id);
        if (entity == null) return true;

        dbContext.UserPasswords.Remove((UserPassword)entity);
        dbContext.SaveChanges();
        return true;
    }

    public IUserPassword? FindByUserId(int userId)
    {
        return dbContext.UserPasswords.FirstOrDefault(i => i.UserId == userId);
    }
}