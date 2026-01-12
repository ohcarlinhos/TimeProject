using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    IList<IPeriod> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    IList<ISession> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    IList<IMinute> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? timeRecord = null);

    int GetTimeRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    int GetTimeRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}