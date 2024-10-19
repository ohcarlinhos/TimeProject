using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.UseCases;

public interface IGetAllTimePeriodUseCase
{
    Task<Result<Pagination<TimePeriodMap>>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}