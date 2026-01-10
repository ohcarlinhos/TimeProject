using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    Task<Result<Pagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}