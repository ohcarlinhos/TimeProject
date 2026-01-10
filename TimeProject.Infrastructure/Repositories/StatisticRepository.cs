using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class StatisticRepository(ProjectContext db) : IStatisticRepository
{
    public Task<List<PeriodRecord>> GetTimePeriodsByRange(
        int userId,
        DateTime initDate,
        DateTime endDate,
        int? timeRecord = null
    )
    {
        var query = db.TimePeriods.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.RecordId == timeRecord);

        return query.Where(e => (
            (e.Start >= initDate && e.Start < endDate) || (e.End > initDate && e.End <= endDate)
        ) && userId == e.UserId).ToListAsync();
    }

    public Task<List<TimerSession>> GetTimerSessionsByRange(
        int userId,
        DateTime initDate,
        DateTime endDate,
        int? timeRecord = null
    )
    {
        var query = db.TimerSessions.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.RecordId == timeRecord);

        return query.Where(p =>
                (
                    (
                        p.PeriodRecords!.Count(e => e.Start >= initDate) > 0
                        &&
                        p.PeriodRecords!.Count(e => e.Start < endDate) > 0
                    )
                    ||
                    (
                        p.PeriodRecords!.Count(e => e.End > initDate) > 0
                        &&
                        p.PeriodRecords!.Count(e => e.End <= endDate) > 0
                    )
                )
                && userId == p.UserId)
            .Include(p => p.PeriodRecords!.OrderBy(q => q.Start))
            .ToListAsync();
    }

    public Task<List<MinuteRecord>> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null)
    {
        var query = db.TimeMinutes.AsQueryable();

        if (timeRecord != null) query = query.Where(i => i.RecordId == timeRecord);

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