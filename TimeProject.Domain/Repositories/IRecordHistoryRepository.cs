using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordHistoryRepository
{
    IList<DateTime> GetDistinctDates(int recordId, int userId, int addHours = 0);

    IList<IPeriod> GetTimePeriodsWithoutTimerSession(int recordId, int userId,
        DateTime initDate, DateTime endDate);

    IList<IMinute> GetTimeMinutes(int recordId, int userId, DateTime initDate,
        DateTime endDate);

    IList<ISession> GetTimerSessions(int recordId, int userId, DateTime initDate,
        DateTime endDate);
}