using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IDeleteTimeRecordUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}