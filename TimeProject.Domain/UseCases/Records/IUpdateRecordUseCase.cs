using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IUpdateRecordUseCase
{
    ICustomResult<IRecordOutDto> Handle(int id, IUpdateRecordDto dto, int userId);
}