using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class PeriodRepository(ProjectContext db) : IPeriodRepository
{
    public IList<IPeriod> Index(int timeRecordId, int userId, IPaginationQuery paginationQuery)
    {
        return db.PeriodRecords
            .Where(timePeriod => timePeriod.RecordId == timeRecordId && timePeriod.UserId == userId)
            .OrderByDescending(tp => tp.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList<IPeriod>();
    }

    public int GetTotalItems(int timeRecordId, IPaginationQuery paginationQuery, int userId)
    {
        return db.PeriodRecords
            .Count(timePeriod => timePeriod.RecordId == timeRecordId && timePeriod.UserId == userId);
    }

    public IPeriod Create(IPeriod entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var periodRecord = (Period)entity;
        periodRecord.CreatedAt = now;
        periodRecord.UpdatedAt = now;

        db.PeriodRecords.Add(periodRecord);
        db.SaveChanges();

        return periodRecord;
    }

    public IList<IPeriod> CreateByList(IList<IPeriod> entities)
    {
        var now = DateTime.Now.ToUniversalTime();
        var list = entities as IList<Period> ?? new List<Period>();

        foreach (var pr in list)
        {
            pr.CreatedAt = now;
            pr.UpdatedAt = now;
        }

        db.PeriodRecords.AddRange(list);
        db.SaveChanges();
        return (list as IList<IPeriod>)!;
    }

    public IPeriod Update(IPeriod entity)
    {
        var periodRecord = (Period)entity;
        periodRecord.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.PeriodRecords.Update(periodRecord);
        db.SaveChanges();
        return periodRecord;
    }

    public bool Delete(IPeriod entity)
    {
        db.PeriodRecords.Remove((Period)entity);
        db.SaveChanges();
        return true;
    }

    public bool DeleteByList(IList<IPeriod> entityList)
    {
        db.PeriodRecords.RemoveRange((entityList as IList<Period>)!);
        db.SaveChanges();
        return true;
    }

    public IPeriod? FindById(int id, int userId)
    {
        return db.PeriodRecords
            .FirstOrDefault(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}