using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordHistoryUseCase
{
    public ICustomResult<IPagination<IRecordHistoryDayOutDto>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery);
}