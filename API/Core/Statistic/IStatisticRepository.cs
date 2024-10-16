using Entities;

namespace API.Core.Statistic;

public interface IStatisticRepository
{
    Task<List<TimePeriodEntity>> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate);
    Task<List<TimerSessionEntity>> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate);
    Task<int> TimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    Task<int> TimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}