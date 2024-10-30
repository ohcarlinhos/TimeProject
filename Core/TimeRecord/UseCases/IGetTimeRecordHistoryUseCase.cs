using System.Security.Claims;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace Core.TimeRecord.UseCases;

public interface IGetTimeRecordHistoryUseCase
{
    public Task<Result<Pagination<TimeRecordHistoryDayMap>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery);
}