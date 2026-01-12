using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class MinuteRepository(ProjectContext db) : IMinuteRepository
{
    public IMinute Create(IMinute entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var mr = (Minute)entity;
        mr.CreatedAt = now;
        mr.UpdatedAt = now;

        db.MinuteRecords.Add(mr);
        db.SaveChanges();
        return mr;
    }

    public IList<IMinute> CreateByList(IList<IMinute> entities)
    {
        var now = DateTime.Now.ToUniversalTime();
        var list = entities as IList<Minute> ?? new List<Minute>();

        foreach (var mr in list)
        {
            mr.CreatedAt = now;
            mr.UpdatedAt = now;
        }

        db.MinuteRecords.AddRange(list);
        db.SaveChanges();

        return (list as IList<IMinute>)!;
    }

    public IMinute? FindById(int id, int userId)
    {
        return db.MinuteRecords.FirstOrDefault(e => e.Id == id && e.UserId == userId);
    }

    public bool Delete(IMinute entity)
    {
        db.MinuteRecords.Remove((Minute)entity);
        db.SaveChanges();
        return true;
    }
}