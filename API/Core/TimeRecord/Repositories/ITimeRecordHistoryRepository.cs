using Entities;

namespace API.Core.TimeRecord.Repositories;

public interface ITimeRecordHistoryRepository
{
    Task<List<DateTime>> GetDistinctDates(int timeRecordId, int userId, int addHours = 0);

    Task<List<TimePeriodEntity>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate);

    Task<List<TimerSessionEntity>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);
}