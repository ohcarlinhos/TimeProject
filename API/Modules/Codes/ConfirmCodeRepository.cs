using Core.Codes;
using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Codes;

public class ConfirmCodeRepository(ProjectContext db) : IConfirmCodeRepository
{
    public async Task<ConfirmCodeEntity> Create(ConfirmCodeEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.ConfirmCodes.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<ConfirmCodeEntity> Update(ConfirmCodeEntity entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.ConfirmCodes.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }


    public async Task<ConfirmCodeEntity?> FindByIdAndEmail(string id, string email)
    {
        return await db.ConfirmCodes.Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == id && e.User!.Email == email);
    }

    public async Task<List<ConfirmCodeEntity>> FindByUserId(int userId)
    {
        return await db.ConfirmCodes
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<ConfirmCodeEntity>> FindByUserId(int userId, ConfirmCodeType type)
    {
        return await db.ConfirmCodes
            .Where(e => e.UserId == userId && e.Type == type)
            .ToListAsync();
    }

    public async Task<ConfirmCodeEntity?> FindById(string id)
    {
        return await db.ConfirmCodes.FirstOrDefaultAsync(e => e.Id == id);
    }
}