using Shared.General;
using Shared.General.Pagination;
using Shared.TimeRecord;

namespace API.Core.TimeRecord.UseCases;

public interface IGetAllTimeRecordUseCase
{
    Task<Result<Pagination<TimeRecordMap>>> Handle(PaginationQuery paginationQuery, int userId);
}