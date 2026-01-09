using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetPaginatedTimeRecordUseCase
{
    Task<Result<Pagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}