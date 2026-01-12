using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class PeriodRecordRepository(ProjectContext db) : IPeriodRecordRepository
{
    public IList<IPeriodRecord> Index(int timeRecordId, int userId, IPaginationQuery paginationQuery)
    {
        return db.PeriodRecords
            .Where(timePeriod => timePeriod.RecordId == timeRecordId && timePeriod.UserId == userId)
            .OrderByDescending(tp => tp.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList<IPeriodRecord>();
    }

    public int GetTotalItems(int timeRecordId, IPaginationQuery paginationQuery, int userId)
    {
        return db.PeriodRecords
            .Count(timePeriod => timePeriod.RecordId == timeRecordId && timePeriod.UserId == userId);
    }

    public IPeriodRecord Create(IPeriodRecord entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var periodRecord = (PeriodRecord)entity;
        periodRecord.CreatedAt = now;
        periodRecord.UpdatedAt = now;

        db.PeriodRecords.Add(periodRecord);
        db.SaveChanges();

        return periodRecord;
    }

    public IList<IPeriodRecord> CreateByList(IList<IPeriodRecord> entities)
    {
        var now = DateTime.Now.ToUniversalTime();
        var list = entities as IList<PeriodRecord> ?? new List<PeriodRecord>();

        foreach (var pr in list)
        {
            pr.CreatedAt = now;
            pr.UpdatedAt = now;
        }

        db.PeriodRecords.AddRange(list);
        db.SaveChanges();
        return (list as IList<IPeriodRecord>)!;
    }

    public IPeriodRecord Update(IPeriodRecord entity)
    {
        var periodRecord = (PeriodRecord)entity;
        periodRecord.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.PeriodRecords.Update(periodRecord);
        db.SaveChanges();
        return periodRecord;
    }

    public bool Delete(IPeriodRecord entity)
    {
        db.PeriodRecords.Remove((PeriodRecord)entity);
        db.SaveChanges();
        return true;
    }

    public bool DeleteByList(IList<IPeriodRecord> entityList)
    {
        db.PeriodRecords.RemoveRange((entityList as IList<PeriodRecord>)!);
        db.SaveChanges();
        return true;
    }

    public IPeriodRecord? FindById(int id, int userId)
    {
        return db.PeriodRecords
            .FirstOrDefault(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}