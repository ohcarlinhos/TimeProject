using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class MinuteRepository(CustomDbContext db) : IMinuteRepository
{
    public IMinute Create(IMinute entity)
    {
        db.Minutes.Add((Minute)entity);
        db.SaveChanges();
        return entity;
    }

    public IList<IMinute> CreateByList(IList<IMinute> entities)
    {
        db.Minutes.AddRange(entities.OfType<Minute>());
        db.SaveChanges();
        return entities;
    }

    public IMinute? FindById(int id, int userId)
    {
        return db.Minutes.FirstOrDefault(e => e.MinuteId == id && e.UserId == userId);
    }

    public bool Delete(IMinute entity)
    {
        db.Minutes.Remove((Minute)entity);
        db.SaveChanges();
        return true;
    }
}