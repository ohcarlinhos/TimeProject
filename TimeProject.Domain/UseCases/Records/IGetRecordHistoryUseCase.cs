using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IGetRecordHistoryUseCase
{
    public ICustomResult<IPagination<IRecordHistoryDayOutDto>> Handle(int timeRecordId, int userId,
        IPaginationQuery paginationQuery);
}