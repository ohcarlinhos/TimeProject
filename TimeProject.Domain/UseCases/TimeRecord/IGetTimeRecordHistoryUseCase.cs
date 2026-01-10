using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordHistoryUseCase
{
    public Task<Result<Pagination<TimeRecordHistoryDayOutDto>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery);
}