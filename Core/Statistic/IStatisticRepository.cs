using Entities;

namespace Core.Statistic;

public interface IStatisticRepository
{
    Task<List<TimePeriodEntity>> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate, int? timeRecord = null);
    Task<List<TimerSessionEntity>> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate, int? timeRecord = null);
    Task<int> TimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    Task<int> TimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}