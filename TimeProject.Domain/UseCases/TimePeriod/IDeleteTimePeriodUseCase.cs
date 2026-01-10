using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IDeleteTimePeriodUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}