using Shared.General;
using Shared.General.Pagination;
using Shared.General.Repositories;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public interface ITimePeriodHistoryRepository
{
    Task<IndexRepositoryResult<HistoryDay>> Index(int timeRecordId, int userId, PaginationQuery paginationQuery);
}