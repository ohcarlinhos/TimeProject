using System.Security.Claims;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Services;

public interface ITimePeriodServices
{
    public Task<Result<Pagination<TimePeriodMap>>> Index(
        int timeRecordId,
        PaginationQuery paginationQuery,
        ClaimsPrincipal user
    );

    public Task<Result<IEnumerable<DatedTimeMap>>> Dated(
        int timeRecordId,
        ClaimsPrincipal user
    );

    Task<Result<Entities.TimePeriod>> Create(
        CreateTimePeriodDto dto,
        ClaimsPrincipal user
    );

    Task<Result<List<Entities.TimePeriod>>> CreateByList(
        TimePeriodListDto dto,
        int timeRecordId,
        ClaimsPrincipal user
    );

    Task<Result<Entities.TimePeriod>> Update(int id, TimePeriodDto dto, ClaimsPrincipal user);

    Task<Result<bool>> Delete(int id, ClaimsPrincipal user);
}