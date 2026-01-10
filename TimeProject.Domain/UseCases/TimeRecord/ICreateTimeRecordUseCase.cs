using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ICreateTimeRecordUseCase
{
    Task<ICustomResult<TimeRecordOutDto>> Handle(CreateTimeRecordDto dto, int userId);
}