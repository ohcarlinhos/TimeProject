using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace Core.TimePeriod.UseCases;

public interface IGetPaginatedTimePeriodUseCase
{
    Task<Result<Pagination<TimePeriodMap>>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}