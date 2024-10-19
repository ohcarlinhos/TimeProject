using Shared.General;
using Shared.TimeRecord;

namespace API.Core.TimeRecord.UseCases;

public interface IGetTimeRecordByCodeUseCase
{
    Task<Result<TimeRecordMap>> Handle(string code, int userId);
}