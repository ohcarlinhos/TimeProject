using Shared.General;
using Shared.General.Pagination;
using Shared.TimeRecord;

namespace Core.TimeRecord.UseCases;

public interface IGetPaginatedTimeRecordUseCase
{
    Task<Result<Pagination<TimeRecordMap>>> Handle(PaginationQuery paginationQuery, int userId);
}