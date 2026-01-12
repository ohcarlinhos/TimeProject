using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class RecordHistoryRepository(ProjectContext db) : IRecordHistoryRepository
{
    public IList<DateTime> GetDistinctDates(int timeRecordId, int userId, int addHours = 0)
    {
        var dateList = new List<DateTime>();

        var datesFromTimePeriods = TimePeriodQuery(timeRecordId, userId)
            .Select(e => e.Start)
            .ToList();

        var datesFromTimeMinutes = TimeMinuteQuery(timeRecordId, userId)
            .Select(e => e.Date)
            .ToList();

        dateList.AddRange(datesFromTimePeriods);
        dateList.AddRange(datesFromTimeMinutes);

        return dateList
            .Select(e => e.AddHours(addHours).Date)
            .Distinct()
            .OrderByDescending(p => p)
            .ToList();
    }

    public IList<IPeriod> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate)
    {
        return TimePeriodQuery(timeRecordId, userId)
            .Where(e =>
                e.TimerSessionId == null
                && e.Start >= initDate
                && e.Start < endDate
            )
            .OrderBy(tp => tp.Start)
            .ToList();
    }

    public IList<IMinute> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return TimeMinuteQuery(timeRecordId, userId)
            .Where(e => e.Date >= initDate && e.Date < endDate)
            .OrderBy(e => e.Date)
            .ToList();
    }

    public IList<ISession> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return TimerSessionQuery(timeRecordId, userId)
            .Where(e =>
                e.PeriodRecords!.FirstOrDefault()!.Start >= initDate
                && e.PeriodRecords!.FirstOrDefault()!.Start < endDate
            )
            .Include(e => e.PeriodRecords!.OrderBy(tp => tp.Start))
            .ToList<ISession>();
    }

    private IQueryable<IPeriod> TimePeriodQuery(int timeRecordId, int userId)
    {
        return db.PeriodRecords
            .Where(e => e.UserId == userId && e.RecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<IMinute> TimeMinuteQuery(int timeRecordId, int userId)
    {
        return db.MinuteRecords
            .Where(e => e.UserId == userId && e.RecordId == timeRecordId)
            .AsQueryable();
    }

    private IQueryable<Session> TimerSessionQuery(int timeRecordId, int userId)
    {
        return db.RecordSessions
            .Where(e =>
                e.UserId == userId
                && e.RecordId == timeRecordId
                && e.PeriodRecords != null
                && e.PeriodRecords.Any()
            )
            .AsQueryable();
    }
}