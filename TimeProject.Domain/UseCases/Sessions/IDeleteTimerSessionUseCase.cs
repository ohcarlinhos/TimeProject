using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Sessions;

public interface IDeleteTimerSessionUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}