using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByIdUseCase
{
    Task<Result<TimeRecordEntity>> Handle(int id, int userId);
}