using Microsoft.EntityFrameworkCore;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserPasswordRepository(ProjectContext dbContext) : IUserPasswordRepository
{
    public async Task<bool> Create(UserPasswordEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.UserPasswords.Add(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(UserPasswordEntity entity)
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

    public async Task<UserPasswordEntity?> FindByUserId(int userId)
    {
        return await dbContext.UserPasswords.FirstOrDefaultAsync(i => i.UserId == userId);
    }
}