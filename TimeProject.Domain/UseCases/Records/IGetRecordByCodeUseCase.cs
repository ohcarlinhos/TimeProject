using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IGetRecordByCodeUseCase
{
    ICustomResult<IRecordOutDto> Handle(string code, int userId);
}