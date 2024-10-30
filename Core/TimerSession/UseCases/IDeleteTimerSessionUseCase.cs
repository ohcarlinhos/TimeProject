using Shared.General;

namespace Core.TimerSession.UseCases;

public interface IDeleteTimerSessionUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}