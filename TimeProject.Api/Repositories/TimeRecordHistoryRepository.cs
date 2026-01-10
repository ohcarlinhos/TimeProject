using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.TimeRecord.Repositories;

namespace TimeProject.Api.Repositories;

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

    public async Task<List<TimePeriodEntity>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
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

    public async Task<List<TimeMinuteEntity>> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return await TimeMinuteQuery(timeRecordId, userId)
            .Where(e => e.Date >= initDate && e.Date < endDate)
            .OrderBy(e => e.Date)
            .ToListAsync();
    }

    public async Task<List<TimerSessionEntity>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return await TimerSessionQuery(timeRecordId, userId)
            .Where(e =>
                e.TimePeriods!.FirstOrDefault()!.Start >= initDate
                && e.TimePeriods!.FirstOrDefault()!.Start < endDate
            )
            .Include(e => e.TimePeriods!.OrderBy(tp => tp.Start))
            .ToListAsync();
    }

    private IQueryable<TimePeriodEntity> TimePeriodQuery(int timeRecordId, int userId)
    {
        return db.TimePeriods
            .Where(e => e.UserId == userId && e.TimeRecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<TimeMinuteEntity> TimeMinuteQuery(int timeRecordId, int userId)
    {
        return db.TimeMinutes
            .Where(e => e.UserId == userId && e.TimeRecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<TimerSessionEntity> TimerSessionQuery(int timeRecordId, int userId)
    {
        return db.TimerSessions
            .Where(e =>
                e.UserId == userId
                && e.TimeRecordId == timeRecordId
                && e.TimePeriods != null
                && e.TimePeriods.Any()
            )
            .AsQueryable();
    }
}