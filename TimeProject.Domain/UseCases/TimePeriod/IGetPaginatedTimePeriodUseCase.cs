using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IGetPaginatedTimePeriodUseCase
{
    ICustomResult<IPagination<IPeriodOutDto>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}