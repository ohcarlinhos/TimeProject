using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimerSession;

public interface IDeleteTimerSessionUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}