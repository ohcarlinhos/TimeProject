using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IGetRecordByIdUseCase
{
    ICustomResult<IRecord> Handle(int id, int userId);
}