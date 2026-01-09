using TimeProject.Core.Application.General;
using TimeProject.Core.Application.Dtos.TimeRecord;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    Task<Result<TimeRecordOutDto>> Handle(int id, UpdateTimeRecordDto dto, int userId);
}