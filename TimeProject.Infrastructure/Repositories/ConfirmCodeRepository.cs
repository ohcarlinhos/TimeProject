using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class ConfirmCodeRepository(ProjectContext db) : IConfirmCodeRepository
{
    public async Task<ConfirmCode> Create(ConfirmCode entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.ConfirmCodes.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<ConfirmCode> Update(ConfirmCode entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.ConfirmCodes.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }


    public async Task<ConfirmCode?> FindByIdAndEmail(string id, string email)
    {
        return await db.ConfirmCodes.Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == id && e.User!.Email == email);
    }

    public async Task<IList<ConfirmCode>> FindByUserId(int userId)
    {
        return await db.ConfirmCodes
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }

    public async Task<IList<ConfirmCode>> FindByUserId(int userId, ConfirmCodeType type)
    {
        return await db.ConfirmCodes
            .Where(e => e.UserId == userId && e.Type == type)
            .ToListAsync();
    }

    public async Task<IList<ConfirmCode>> FindByUserIdThatIsNotExpiredOrUsed(int userId, ConfirmCodeType type)
    {
        var now = DateTime.Now.ToUniversalTime();
        return await db.ConfirmCodes
            .Where(e => e.UserId == userId && e.Type == type && now < e.ExpireDate && e.IsUsed == false)
            .ToListAsync();
    }

    public async Task<ConfirmCode?> FindById(string id)
    {
        return await db.ConfirmCodes.FirstOrDefaultAsync(e => e.Id == id);
    }
}