using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ICreateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(CreateTimeRecordDto dto, int userId);
}