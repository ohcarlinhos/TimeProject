using Entities;

namespace Core.Statistic;

public interface IStatisticRepository
{
    Task<List<TimePeriodEntity>> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<List<TimerSessionEntity>> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<List<TimeMinuteEntity>> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<int> GetTimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    Task<int> GetTimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}