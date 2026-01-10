using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    Task<ICustomResult<IPagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}