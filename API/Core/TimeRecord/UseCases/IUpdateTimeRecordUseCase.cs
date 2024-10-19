using Shared.General;
using Shared.TimeRecord;

namespace API.Core.TimeRecord.UseCases;

public interface IUpdateTimeRecordUseCase
{
    Task<Result<TimeRecordMap>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}