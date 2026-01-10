using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserPasswordRepository(ProjectContext dbContext) : IUserPasswordRepository
{
    public async Task<bool> Create(UserPassword entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.UserPasswords.Add(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(UserPassword entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.UserPasswords.Update(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await FindByUserId(id);
        if (entity == null) return true;

        dbContext.UserPasswords.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<UserPassword?> FindByUserId(int userId)
    {
        return await dbContext.UserPasswords.FirstOrDefaultAsync(i => i.UserId == userId);
    }
}