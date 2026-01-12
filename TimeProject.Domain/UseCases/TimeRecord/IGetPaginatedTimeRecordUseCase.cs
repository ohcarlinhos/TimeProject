using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    ICustomResult<IPagination<IRecordOutDto>> Handle(PaginationQuery paginationQuery, int userId);
}