using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IDeleteTimeRecordUseCase
{
    Task<ICustomResult<bool>> Handle(int id, int userId);
}