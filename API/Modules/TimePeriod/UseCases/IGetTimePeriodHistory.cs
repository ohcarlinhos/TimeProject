using System.Security.Claims;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public interface IGetTimePeriodHistory
{
    public Task<Result<IEnumerable<HistoryDayMap>>> Handle(int timeRecordId, ClaimsPrincipal user,
        PaginationQuery paginationQuery);
}