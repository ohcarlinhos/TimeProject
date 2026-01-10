using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ICreateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(CreateTimeRecordDto dto, int userId);
}