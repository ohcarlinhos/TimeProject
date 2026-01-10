using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    Task<Result<Pagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}