using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}