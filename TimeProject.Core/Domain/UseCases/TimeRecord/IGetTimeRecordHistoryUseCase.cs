using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordHistoryUseCase
{
    public Task<Result<Pagination<TimeRecordHistoryDayOutDto>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery);
}