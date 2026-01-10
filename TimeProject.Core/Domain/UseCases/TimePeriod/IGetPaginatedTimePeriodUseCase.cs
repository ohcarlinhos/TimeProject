using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface IGetPaginatedTimePeriodUseCase
{
    Task<Result<Pagination<TimePeriodOutDto>>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}