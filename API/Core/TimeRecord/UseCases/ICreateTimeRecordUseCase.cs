using Shared.General;
using Shared.TimeRecord;

namespace API.Core.TimeRecord.UseCases;

public interface ICreateTimeRecordUseCase
{
    Task<Result<TimeRecordMap>> Handle(CreateTimeRecordDto dto, int userId);
}