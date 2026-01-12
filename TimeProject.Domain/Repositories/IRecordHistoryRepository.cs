using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordHistoryRepository
{
    IList<DateTime> GetDistinctDates(int recordId, int userId, int addHours = 0);

    IList<IPeriod> GetPeriodsWithoutSession(int recordId, int userId,
        DateTime initDate, DateTime endDate);

    IList<IMinute> GetMinutes(int recordId, int userId, DateTime initDate,
        DateTime endDate);

    IList<ISession> GetSessions(int recordId, int userId, DateTime initDate,
        DateTime endDate);
}