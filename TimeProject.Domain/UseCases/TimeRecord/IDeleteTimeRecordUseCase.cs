using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IDeleteTimeRecordUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}