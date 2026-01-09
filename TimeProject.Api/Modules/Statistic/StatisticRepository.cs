using Core.Statistic;
using Entities;
using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;

namespace TimeProject.Api.Modules.Statistic;

public class StatisticRepository(ProjectContext db) : IStatisticRepository
{
    public Task<List<TimePeriodEntity>> GetTimePeriodsByRange(
        int userId,
        DateTime initDate,
        DateTime endDate,
        int? timeRecord = null
    )
    {
        var query = db.TimePeriods.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.TimeRecordId == timeRecord);

        return query.Where(e => (
            (e.Start >= initDate && e.Start < endDate) || (e.End > initDate && e.End <= endDate)
        ) && userId == e.UserId).ToListAsync();
    }

    public Task<List<TimerSessionEntity>> GetTimerSessionsByRange(
        int userId,
        DateTime initDate,
        DateTime endDate,
        int? timeRecord = null
    )
    {
        var query = db.TimerSessions.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.TimeRecordId == timeRecord);

        return query.Where(p =>
                (
                    (
                        p.TimePeriods!.Count(e => e.Start >= initDate) > 0
                        &&
                        p.TimePeriods!.Count(e => e.Start < endDate) > 0
                    )
                    ||
                    (
                        p.TimePeriods!.Count(e => e.End > initDate) > 0
                        &&
                        p.TimePeriods!.Count(e => e.End <= endDate) > 0
                    )
                )
                && userId == p.UserId)
            .Include(p => p.TimePeriods!.OrderBy(q => q.Start))
            .ToListAsync();
    }

    public Task<List<TimeMinuteEntity>> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null)
    {
        var query = db.TimeMinutes.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.TimeRecordId == timeRecord);

        return query.Where(tm =>
                tm.UserId == userId
                && tm.Date >= initDate
                && tm.Date < endDate
            )
            .OrderBy(tm => tm.Date)
            .ToListAsync();
    }

    public Task<int> GetTimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate)
    {
        return db.TimeRecords
            .Where(e => e.CreatedAt >= initDate && e.CreatedAt < endDate && userId == e.UserId)
            .CountAsync();
    }

    public Task<int> GetTimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate)
    {
        return db
            .TimeRecords
            .Where(e => e.UpdatedAt >= initDate
                        && e.UpdatedAt < endDate
                        && e.UpdatedAt != e.CreatedAt
                        && userId == e.UserId
            )
            .CountAsync();
    }
}