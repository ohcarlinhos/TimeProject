using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Repositories;

public class ConfirmCodeRepository(CustomDbContext db) : IConfirmCodeRepository
{
    public IConfirmCode Create(IConfirmCode entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var confirmCode = (ConfirmCode)entity;
        confirmCode.CreatedAt = now;
        confirmCode.UpdatedAt = now;

        db.ConfirmCodes.Add(confirmCode);
        db.SaveChanges();
        return entity;
    }

    public IConfirmCode Update(IConfirmCode entity)
    {
        var confirmCode = (ConfirmCode)entity;
        confirmCode.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.ConfirmCodes.Update(confirmCode);
        db.SaveChanges();
        return entity;
    }


    public IConfirmCode? FindByIdAndEmail(string id, string email)
    {
        return db.ConfirmCodes.Include(e => e.User)
            .FirstOrDefault(e => e.Id == id && e.User!.Email == email);
    }

    public IList<IConfirmCode> FindByUserId(int userId)
    {
        return db.ConfirmCodes
            .Where(e => e.UserId == userId)
            .ToList<IConfirmCode>();
    }

    public IList<IConfirmCode> FindByUserId(int userId, ConfirmCodeType type)
    {
        return db.ConfirmCodes
            .Where(e => e.UserId == userId && e.Type == type)
            .ToList<IConfirmCode>();
    }

    public IList<IConfirmCode> FindByUserIdThatIsNotExpiredOrUsed(int userId, ConfirmCodeType type)
    {
        var now = DateTime.Now.ToUniversalTime();
        return db.ConfirmCodes
            .Where(e => e.UserId == userId && e.Type == type && now < e.ExpireDate && e.IsUsed == false)
            .ToList<IConfirmCode>();
    }

    public IConfirmCode? FindById(string id)
    {
        return db.ConfirmCodes.FirstOrDefault(e => e.Id == id);
    }
}