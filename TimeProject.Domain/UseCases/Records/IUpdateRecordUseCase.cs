using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IUpdateRecordUseCase
{
    ICustomResult<IRecordOutDto> Handle(int id, IUpdateRecordDto dto, int userId);
}