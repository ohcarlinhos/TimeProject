using Shared.General;
using Shared.TimeRecord;

namespace Core.TimeRecord.UseCases;

public interface IGetTimeRecordByCodeUseCase
{
    Task<Result<TimeRecordMap>> Handle(string code, int userId);
}