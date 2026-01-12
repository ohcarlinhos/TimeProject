using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    ICustomResult<ITimeRecordOutDto> Handle(int id, IUpdateTimeRecordDto dto, int userId);
}