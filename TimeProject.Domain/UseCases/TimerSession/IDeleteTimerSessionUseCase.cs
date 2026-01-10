using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimerSession;

public interface IDeleteTimerSessionUseCase
{
    Task<ICustomResult<bool>> Handle(int id, int userId);
}