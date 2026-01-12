using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class MinuteRecordRepository(ProjectContext db) : IMinuteRecordRepository
{
    public IMinuteRecord Create(IMinuteRecord entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var mr = (MinuteRecord)entity;
        mr.CreatedAt = now;
        mr.UpdatedAt = now;

        db.MinuteRecords.Add(mr);
        db.SaveChanges();
        return mr;
    }

    public IList<IMinuteRecord> CreateByList(IList<IMinuteRecord> entities)
    {
        var now = DateTime.Now.ToUniversalTime();
        var list = entities as IList<MinuteRecord> ?? new List<MinuteRecord>();

        foreach (var mr in list)
        {
            mr.CreatedAt = now;
            mr.UpdatedAt = now;
        }

        db.MinuteRecords.AddRange(list);
        db.SaveChanges();

        return (list as IList<IMinuteRecord>)!;
    }

    public IMinuteRecord? FindById(int id, int userId)
    {
        return db.MinuteRecords.FirstOrDefault(e => e.Id == id && e.UserId == userId);
    }

    public bool Delete(IMinuteRecord entity)
    {
        db.MinuteRecords.Remove((MinuteRecord)entity);
        db.SaveChanges();
        return true;
    }
}