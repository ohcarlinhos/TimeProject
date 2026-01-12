using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Minutes;

public interface IDeleteTimeMinuteUseCase
{
    public ICustomResult<bool> Handle(int id, int userId);
}