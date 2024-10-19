using System.Security.Claims;
using Entities;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Core.TimePeriod;

public interface ITimePeriodServices
{
    public Task<Result<Pagination<TimePeriodMap>>> Index(
        int timeRecordId,
        ClaimsPrincipal user,
        PaginationQuery paginationQuery
    );

    Task<Result<TimePeriodEntity>> Create(
        CreateTimePeriodDto dto,
        ClaimsPrincipal user
    );

    Task<Result<List<TimePeriodEntity>>> CreateByList(
        TimePeriodListDto dto,
        int timeRecordId,
        int userId
    );

    Task<Result<TimePeriodEntity>> Update(int id, TimePeriodDto dto, ClaimsPrincipal user);

    Task<Result<bool>> Delete(int id, ClaimsPrincipal user);
}