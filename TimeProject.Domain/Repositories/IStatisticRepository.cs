using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    IList<IPeriod> GetPeriodsByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    IList<ISession> GetSessionsByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    IList<IMinute> GetTimeMinutesByRange(int userId, DateTime initDate, DateTime endDate,
        int? recordId = null);

    int GetRecordCreatedCount(int userId, DateTime initDate, DateTime endDate);
    int GetRecordUpdatedCount(int userId, DateTime initDate, DateTime endDate);
}