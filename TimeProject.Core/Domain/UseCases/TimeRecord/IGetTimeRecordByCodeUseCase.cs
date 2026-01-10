using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByCodeUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(string code, int userId);
}