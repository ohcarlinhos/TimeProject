using Shared.General;

namespace API.Core.TimerSession.UseCases;

public interface IDeleteTimerSessionUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}