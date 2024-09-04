using System.Runtime.InteropServices;
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

    public async Task<DatedResult> Dated(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        var timePeriodQuery = dbContext.TimePeriods
            .Where(p => p.UserId == userId && p.TimeRecordId == timeRecordId).AsQueryable();

        var timerSessionQuery = dbContext.TimerSessions.Where(p =>
                p.UserId == userId && p.TimeRecordId == timeRecordId && p.TimePeriods != null && p.TimePeriods.Any())
            .AsQueryable();

        var dates = await timePeriodQuery
            .Select((p) => p.Start)
            .OrderByDescending(p => p.Date)
            .ToListAsync();

        var timePeriods = await timePeriodQuery
            .Where((p) => p.TimerSessionId == null)
            .OrderByDescending(p => p.Start).ToListAsync();

        var timerSessions = await timerSessionQuery
            .OrderByDescending(p => p.TimePeriods!.FirstOrDefault()!.Start.Date)
            .Include(p => p.TimePeriods!.OrderByDescending(q => q.Start))
            .ToListAsync();

        var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "E. South America Standard Time"
            : "America/Sao_Paulo");
        
        var datedTimePeriods = new List<DatedTimePeriod>();

        dates = dates.Select(p => TimeZoneInfo.ConvertTimeFromUtc(p, brasiliaTimeZone).Date).Distinct().ToList();

        foreach (var d in dates)
        {
            var tpList = timePeriods
                .Where(p => TimeZoneInfo
                    .ConvertTimeFromUtc(p.Start, brasiliaTimeZone).Date == d)
                .OrderBy(p => p.Start)
                .ToList();

            var tsList = timerSessions
                .Where(a => a.TimePeriods!.Any())
                .Where(p => TimeZoneInfo
                    .ConvertTimeFromUtc(p.TimePeriods!.FirstOrDefault()!.Start, brasiliaTimeZone)
                    .Date == d.Date)
                .ToList();

            datedTimePeriods.Add(new DatedTimePeriod
            {
                Date = d.Date, TimePeriods = tpList, TimerSessions = tsList
            });
        }

        return new DatedResult
        {
            DatedTimePeriods = datedTimePeriods,
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