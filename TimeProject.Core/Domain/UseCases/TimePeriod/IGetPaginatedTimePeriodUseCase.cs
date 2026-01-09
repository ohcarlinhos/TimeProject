using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface IGetPaginatedTimePeriodUseCase
{
    Task<Result<Pagination<TimePeriodOutDto>>> Handle(int timeRecordId, int userId, PaginationQuery paginationQuery);
}