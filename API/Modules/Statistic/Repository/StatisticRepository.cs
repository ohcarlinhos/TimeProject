using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Statistic.Repository;

public class StatisticRepository(ProjectContext db) : IStatisticRepository
{
    public Task<List<TimePeriodEntity>> GetTimePeriodsByRange(int userId, DateTime initDate,
        DateTime endDate)
    {
        return db.TimePeriods
            .Where(e => ((e.Start >= initDate && e.Start < endDate) || (e.End > initDate && e.End <= endDate))
                        && userId == e.UserId)
            .ToListAsync();
    }

    public Task<List<TimerSessionEntity>> GetTimerSessionsByRange(
        int userId,
        DateTime initDate,
        DateTime endDate
    )
    {
        return db.TimerSessions
            .Where(p => p.TimePeriods!.FirstOrDefault()!.Start >= initDate &&
                        p.TimePeriods!.FirstOrDefault()!.Start < endDate && userId == p.UserId)
            .Include(p => p.TimePeriods!.OrderBy(q => q.Start))
            .ToListAsync();
    }

    public Task<int> TimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate)
    {
        return db.TimeRecords
            .Where((e) => e.CreatedAt >= initDate && e.CreatedAt < endDate && userId == e.UserId)
            .CountAsync();
    }

    public Task<int> TimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate)
    {
        return db.TimeRecords
            .Where((e) => e.UpdatedAt >= initDate && e.UpdatedAt < endDate && userId == e.UserId)
            .CountAsync();
    }
}