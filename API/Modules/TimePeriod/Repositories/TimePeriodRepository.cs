using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodRepository(ProjectContext dbContext) : ITimePeriodRepository
{
    public List<Entities.TimePeriod> Index(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        return dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .OrderByDescending(tp => tp.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        return await dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .CountAsync();
    }

    public DatedResult Dated(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        var timePeriodQuery = dbContext.TimePeriods.AsQueryable();
        timePeriodQuery = timePeriodQuery.Where(p => p.UserId == userId && p.TimeRecordId == timeRecordId);

        var dateQuery = timePeriodQuery.GroupBy(p => p.Start.Date);

        var resultList = dateQuery
            .Select(p => new { p.Key, Count = p.Count() })
            .OrderByDescending(p => p.Key)
            .ToList();

        var totalItems = dateQuery.Count();

        var datedTimePeriods = new List<DatedTimePeriod>();

        foreach (var result in resultList)
        {
            var query = timePeriodQuery
                .Where(p => p.Start.Date == result.Key.Date)
                .OrderByDescending(p => p.Start)
                .ToList();
            datedTimePeriods.Add(new DatedTimePeriod
                { Date = result.Key.Date.ToString("yyyy-MM-dd"), Count = result.Count, TimePeriods = query });
        }

        return new DatedResult
        {
            DatedTimePeriods = datedTimePeriods,
            TotalItems = totalItems
        };
    }

    public async Task<Entities.TimePeriod> Create(Entities.TimePeriod entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.TimePeriods.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<Entities.TimePeriod>> CreateByList(List<Entities.TimePeriod> entityList)
    {
        var now = DateTime.Now.ToUniversalTime();

        foreach (var entity in entityList)
        {
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
        }

        dbContext.TimePeriods.AddRange(entityList);
        await dbContext.SaveChangesAsync();
        return entityList;
    }

    public async Task<Entities.TimePeriod> Update(Entities.TimePeriod entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.TimePeriods.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Entities.TimePeriod entity)
    {
        dbContext.TimePeriods.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByTimeRecordId(IEnumerable<Entities.TimePeriod> entityList)
    {
        dbContext.TimePeriods.RemoveRange(entityList);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Entities.TimePeriod?> FindById(int id, int userId)
    {
        return await dbContext.TimePeriods
            .FirstOrDefaultAsync(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}