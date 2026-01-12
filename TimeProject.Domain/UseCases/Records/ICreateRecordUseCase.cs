using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface ICreateRecordUseCase
{
    ICustomResult<IRecordOutDto> Handle(ICreateRecordDto dto, int userId);
}