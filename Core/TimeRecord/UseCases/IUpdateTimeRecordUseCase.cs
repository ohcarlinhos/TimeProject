using Shared.General;
using Shared.TimeRecord;

namespace Core.TimeRecord.UseCases;

public interface IUpdateTimeRecordUseCase
{
    Task<Result<TimeRecordMap>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}