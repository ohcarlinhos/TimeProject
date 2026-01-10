using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.TimeRecord.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class TimeRecordHistoryRepository(ProjectContext db) : ITimeRecordHistoryRepository
{
    public async Task<List<DateTime>> GetDistinctDates(int timeRecordId, int userId, int addHours = 0)
    {
        var dateList = new List<DateTime>();

        var datesFromTimePeriods = await TimePeriodQuery(timeRecordId, userId)
            .Select(e => e.Start)
            .ToListAsync();

        var datesFromTimeMinutes = await TimeMinuteQuery(timeRecordId, userId)
            .Select(e => e.Date)
            .ToListAsync();

        dateList.AddRange(datesFromTimePeriods);
        dateList.AddRange(datesFromTimeMinutes);

        return dateList
            .Select(e => e.AddHours(addHours).Date)
            .Distinct()
            .OrderByDescending(p => p)
            .ToList();
    }

    public async Task<List<PeriodRecord>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate)
    {
        return await TimePeriodQuery(timeRecordId, userId)
            .Where(e =>
                e.TimerSessionId == null
                && e.Start >= initDate
                && e.Start < endDate
            )
            .OrderBy(tp => tp.Start)
            .ToListAsync();
    }

    public async Task<List<MinuteRecord>> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return await TimeMinuteQuery(timeRecordId, userId)
            .Where(e => e.Date >= initDate && e.Date < endDate)
            .OrderBy(e => e.Date)
            .ToListAsync();
    }

    public async Task<List<TimerSession>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return await TimerSessionQuery(timeRecordId, userId)
            .Where(e =>
                e.PeriodRecords!.FirstOrDefault()!.Start >= initDate
                && e.PeriodRecords!.FirstOrDefault()!.Start < endDate
            )
            .Include(e => e.PeriodRecords!.OrderBy(tp => tp.Start))
            .ToListAsync();
    }

    private IQueryable<PeriodRecord> TimePeriodQuery(int timeRecordId, int userId)
    {
        return db.TimePeriods
            .Where(e => e.UserId == userId && e.RecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<MinuteRecord> TimeMinuteQuery(int timeRecordId, int userId)
    {
        return db.TimeMinutes
            .Where(e => e.UserId == userId && e.RecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<TimerSession> TimerSessionQuery(int timeRecordId, int userId)
    {
        return db.TimerSessions
            .Where(e =>
                e.UserId == userId
                && e.RecordId == timeRecordId
                && e.PeriodRecords != null
                && e.PeriodRecords.Any()
            )
            .AsQueryable();
    }
}