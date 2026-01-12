using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByIdUseCase
{
    ICustomResult<IRecord> Handle(int id, int userId);
}