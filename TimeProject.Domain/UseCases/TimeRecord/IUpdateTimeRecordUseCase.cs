using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IUpdateTimeRecordUseCase
{
    ICustomResult<IRecordOutDto> Handle(int id, IUpdateRecordDto dto, int userId);
}