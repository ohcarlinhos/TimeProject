using Shared.General;

namespace API.Core.TimeRecord.UseCases;

public interface IDeleteTimeRecordUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}