using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IGetPaginatedRecordUseCase
{
    ICustomResult<IPagination<IRecordOutDto>> Handle(PaginationQuery paginationQuery, int userId);
}