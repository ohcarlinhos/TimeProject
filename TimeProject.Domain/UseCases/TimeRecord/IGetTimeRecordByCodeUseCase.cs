using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByCodeUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(string code, int userId);
}