using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordHistoryUseCase
{
    public Task<Result<Pagination<TimeRecordHistoryDayOutDto>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery);
}