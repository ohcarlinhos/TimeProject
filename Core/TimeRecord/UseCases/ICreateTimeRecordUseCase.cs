using Shared.General;
using Shared.TimeRecord;

namespace Core.TimeRecord.UseCases;

public interface ICreateTimeRecordUseCase
{
    Task<Result<TimeRecordMap>> Handle(CreateTimeRecordDto dto, int userId);
}