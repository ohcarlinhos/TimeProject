using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordHistoryRepository
{
    IList<DateTime> GetDistinctDates(int timeRecordId, int userId, int addHours = 0);

    IList<IPeriod> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate);

    IList<IMinute> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);

    IList<ISession> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);
}