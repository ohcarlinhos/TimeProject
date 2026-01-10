using TimeProject.Domain.Entities;

namespace TimeProject.Domain.TimeRecord.Repositories;

public interface ITimeRecordHistoryRepository
{
    Task<List<DateTime>> GetDistinctDates(int timeRecordId, int userId, int addHours = 0);

    Task<List<PeriodRecord>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate);

    Task<List<MinuteRecord>> GetTimeMinutes(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);

    Task<List<TimerSession>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);
}