using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    IList<IPeriodRecord> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    IList<IRecordSession> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    IList<IMinuteRecord> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    int GetTimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    int GetTimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}