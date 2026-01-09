using Entities;
using Shared.General;

namespace Core.TimeRecord.UseCases;

public interface IGetTimeRecordByIdUseCase
{
    Task<Result<TimeRecordEntity>> Handle(int id, int userId);
}