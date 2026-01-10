using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}