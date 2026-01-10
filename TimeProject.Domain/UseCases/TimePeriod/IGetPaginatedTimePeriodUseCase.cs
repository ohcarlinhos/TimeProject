using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IGetPaginatedTimePeriodUseCase
{
    Task<Result<Pagination<TimePeriodOutDto>>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}