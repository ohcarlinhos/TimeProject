using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    ICustomResult<IPagination<ITimeRecordOutDto>> Handle(PaginationQuery paginationQuery, int userId);
}