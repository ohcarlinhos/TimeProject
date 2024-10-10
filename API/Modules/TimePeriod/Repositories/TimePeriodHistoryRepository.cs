using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Pagination;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodHistoryRepository(ProjectContext db) : ITimePeriodHistoryRepository
{
    private IQueryable<TimePeriodEntity> TimePeriodQuery(int timeRecordId, int userId)
    {
        return db.TimePeriods
            .Where(p => p.UserId == userId && p.TimeRecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<TimerSessionEntity> TimerSessionQuery(int timeRecordId, int userId)
    {
        return db.TimerSessions
            .Where(p =>
                p.UserId == userId && p.TimeRecordId == timeRecordId && p.TimePeriods != null && p.TimePeriods.Any())
            .AsQueryable();
    }


    public async Task<List<DateTime>> GetDistinctDates(int timeRecordId, int userId, int addHours = 0)
    {
        var datesFromQuery = await TimePeriodQuery(timeRecordId, userId)
            .Select(p => p.Start)
            .OrderByDescending(p => p)
            .ToListAsync();

        return datesFromQuery
            .Select(e => e.AddHours(addHours).Date)
            .Distinct()
            .ToList();
    }


    public async Task<List<TimePeriodEntity>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate)
    {
        return await TimePeriodQuery(timeRecordId, userId)
            .Where(p => p.Start >= initDate && p.Start < endDate && p.TimerSessionId == null)
            .OrderBy(p => p.Start)
            .ToListAsync();
    }

    public async Task<List<TimerSessionEntity>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return await TimerSessionQuery(timeRecordId, userId)
            .Where(p => p.TimePeriods!.FirstOrDefault()!.Start >= initDate &&
                        p.TimePeriods!.FirstOrDefault()!.Start < endDate)
            .Include(p => p.TimePeriods!.OrderBy(q => q.Start))
            .ToListAsync();
    }
}