using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class PeriodRepository(CustomDbContext db) : IPeriodRepository
{
    public IList<IPeriod> Index(int recordId, int userId, IPaginationQuery paginationQuery)
    {
        return db.Periods
            .Where(period => period.RecordId == recordId && period.UserId == userId)
            .OrderByDescending(period => period.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList<IPeriod>();
    }

    public int GetTotalItems(int recordId, IPaginationQuery paginationQuery, int userId)
    {
        return db.Periods
            .Count(period => period.RecordId == recordId && period.UserId == userId);
    }

    public IPeriod Create(IPeriod entity)
    {
        db.Periods.Add((Period)entity);
        db.SaveChanges();
        return entity;
    }

    public IList<IPeriod> CreateByList(IList<IPeriod> entities)
    {
        var list = entities.OfType<Period>().ToList();
        db.Periods.AddRange(list);
        db.SaveChanges();
        return entities;
    }

    public IPeriod Update(IPeriod entity)
    {
        db.Periods.Update((Period)entity);
        db.SaveChanges();
        return entity;
    }

    public bool Delete(IPeriod entity)
    {
        db.Periods.Remove((Period)entity);
        db.SaveChanges();
        return true;
    }

    public bool DeleteByList(IList<IPeriod> entityList)
    {
        db.Periods.RemoveRange((entityList as IList<Period>)!);
        db.SaveChanges();
        return true;
    }

    public IPeriod? FindById(int id, int userId)
    {
        return db.Periods
            .FirstOrDefault(period => period.PeriodId == id && period.UserId == userId);
    }
}