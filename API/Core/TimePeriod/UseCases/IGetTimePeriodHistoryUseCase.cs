using System.Security.Claims;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.UseCases;

public interface IGetTimePeriodHistoryUseCase
{
    public Task<Result<Pagination<HistoryPeriodDayMap>>> Handle(int timeRecordId, ClaimsPrincipal user,
        PaginationQuery paginationQuery);
}