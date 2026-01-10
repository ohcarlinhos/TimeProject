using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    Task<ICustomResult<TimeRecordOutDto>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}