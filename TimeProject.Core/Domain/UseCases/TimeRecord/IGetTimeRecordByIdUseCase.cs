using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByIdUseCase
{
    Task<Result<TimeRecordEntity>> Handle(int id, int userId);
}