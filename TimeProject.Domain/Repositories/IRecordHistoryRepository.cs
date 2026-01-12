using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordHistoryRepository
{
    IList<DateTime> GetDistinctDates(int timeRecordId, int userId, int addHours = 0);

    IList<IPeriodRecord> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate);

    IList<IMinuteRecord> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);

    IList<IRecordSession> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);
}