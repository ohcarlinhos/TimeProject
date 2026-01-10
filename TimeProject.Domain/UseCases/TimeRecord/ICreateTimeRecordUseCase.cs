using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ICreateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(CreateTimeRecordDto dto, int userId);
}