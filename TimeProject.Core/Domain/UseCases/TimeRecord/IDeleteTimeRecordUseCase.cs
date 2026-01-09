using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IDeleteTimeRecordUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}