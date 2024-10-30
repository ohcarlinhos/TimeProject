using Shared.General;

namespace Core.TimeRecord.UseCases;

public interface IDeleteTimeRecordUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}