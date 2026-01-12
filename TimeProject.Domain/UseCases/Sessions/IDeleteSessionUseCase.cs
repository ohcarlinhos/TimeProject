using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Sessions;

public interface IDeleteSessionUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}