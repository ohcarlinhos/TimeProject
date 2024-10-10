using Entities;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Repositories;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public interface ITimePeriodHistoryRepository
{
    Task<List<DateTime>> GetDistinctDates(int timeRecordId, int userId, int addHours = 0);
    IEnumerable<DateTime> TakeDatesFromPagination(IEnumerable<DateTime> dates, PaginationQuery paginationQuery);

    Task<List<TimePeriodEntity>> GetTimePeriodsWithoutTimerSession(int timeRecordId, int userId,
        DateTime initDate, DateTime endDate);

    Task<List<TimerSessionEntity>> GetTimerSessions(int timeRecordId, int userId, DateTime initDate,
        DateTime endDate);
}