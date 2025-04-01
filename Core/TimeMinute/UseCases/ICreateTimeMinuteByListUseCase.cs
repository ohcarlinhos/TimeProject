using Entities;
using Shared.General;
using Shared.TimeMinute;

namespace Core.TimeMinute.UseCases;

public interface ICreateTimeMinuteByListUseCase
{
    Task<Result<List<TimeMinuteEntity>>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId);
}