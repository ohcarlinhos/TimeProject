using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class RecordHistoryRepository(ProjectContext db) : IRecordHistoryRepository
{
    public IList<DateTime> GetDistinctDates(int recordId, int userId, int addHours = 0)
    {
        var dateList = new List<DateTime>();

        var datesFromPeriods = PeriodQuery(recordId, userId)
            .Select(e => e.Start)
            .ToList();

        var datesFromMinutes = MinuteQuery(recordId, userId)
            .Select(e => e.Date)
            .ToList();

        dateList.AddRange(datesFromPeriods);
        dateList.AddRange(datesFromMinutes);

        return dateList
            .Select(e => e.AddHours(addHours).Date)
            .Distinct()
            .OrderByDescending(p => p)
            .ToList();
    }

    public IList<IPeriod> GetPeriodsWithoutSession(int recordId, int userId,
        DateTime initDate, DateTime endDate)
    {
        return PeriodQuery(recordId, userId)
            .Where(e =>
                e.SessionId == null
                && e.Start >= initDate
                && e.Start < endDate
            )
            .OrderBy(tp => tp.Start)
            .ToList();
    }

    public IList<IMinute> GetMinutes(int recordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return MinuteQuery(recordId, userId)
            .Where(e => e.Date >= initDate && e.Date < endDate)
            .OrderBy(e => e.Date)
            .ToList();
    }

    public IList<ISession> GetSessions(int recordId, int userId, DateTime initDate,
        DateTime endDate)
    {
        return SessionQuery(recordId, userId)
            .Where(e =>
                e.PeriodRecords!.FirstOrDefault()!.Start >= initDate
                && e.PeriodRecords!.FirstOrDefault()!.Start < endDate
            )
            .Include(e => e.PeriodRecords!.OrderBy(tp => tp.Start))
            .ToList<ISession>();
    }

    private IQueryable<IPeriod> PeriodQuery(int recordId, int userId)
    {
        return db.PeriodRecords
            .Where(e => e.UserId == userId && e.RecordId == recordId)
            .AsQueryable();
    }

    private IQueryable<IMinute> MinuteQuery(int recordId, int userId)
    {
        return db.MinuteRecords
            .Where(e => e.UserId == userId && e.RecordId == recordId)
            .AsQueryable();
    }

    private IQueryable<Session> SessionQuery(int recordId, int userId)
    {
        return db.RecordSessions
            .Where(e =>
                e.UserId == userId
                && e.RecordId == recordId
                && e.PeriodRecords != null
                && e.PeriodRecords.Any()
            )
            .AsQueryable();
    }
}