using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByCodeUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(string code, int userId);
}