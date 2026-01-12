using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    IList<IPeriod> GetTimePeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    IList<ISession> GetTimerSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    IList<IMinute> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    int GetRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    int GetRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}