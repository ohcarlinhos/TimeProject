using System.Security.Claims;
using Entities;
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

    Task<Result<TimePeriodEntity>> Create(
        CreateTimePeriodDto dto,
        ClaimsPrincipal user
    );

    Task<Result<List<TimePeriodEntity>>> CreateByList(
        TimePeriodListDto dto,
        int timeRecordId,
        ClaimsPrincipal user
    );

    Task<Result<TimePeriodEntity>> Update(int id, TimePeriodDto dto, ClaimsPrincipal user);

    Task<Result<bool>> Delete(int id, ClaimsPrincipal user);
}