using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public interface ITimePeriodHistoryRepository
{
    Task<IEnumerable<HistoryDay>> Index(int timeRecordId, int userId, PaginationQuery paginationQuery);
}