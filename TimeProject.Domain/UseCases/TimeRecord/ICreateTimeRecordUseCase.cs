using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ICreateTimeRecordUseCase
{
    ICustomResult<IRecordOutDto> Handle(ICreateRecordDto dto, int userId);
}