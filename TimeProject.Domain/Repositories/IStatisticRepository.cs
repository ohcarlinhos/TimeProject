using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Domain.Repositories;

public interface IStatisticRepository
{
    IList<IPeriod> GetPeriodsByRange(int userId, DateTimeOffset initDate, DateTimeOffset endDate,
        int? recordId = null);

    IList<ISession> GetSessionsByRange(int userId, DateTimeOffset initDate, DateTimeOffset endDate,
        int? recordId = null);

    IList<IMinute> GetTimeMinutesByRange(int userId, DateTimeOffset initDate, DateTimeOffset endDate,
        int? recordId = null);

    int GetRecordCreatedCount(int userId, DateTimeOffset initDate, DateTimeOffset endDate);
    int GetRecordUpdatedCount(int userId, DateTimeOffset initDate, DateTimeOffset endDate);
}