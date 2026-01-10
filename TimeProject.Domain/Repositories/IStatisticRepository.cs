using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    Task<List<PeriodRecord>> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<List<TimerSession>> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<List<MinuteRecord>> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    Task<int> GetTimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    Task<int> GetTimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}