using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimerSession;

public interface IDeleteTimerSessionUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}