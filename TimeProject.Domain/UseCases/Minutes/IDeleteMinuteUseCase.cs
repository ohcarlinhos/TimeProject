using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Minutes;

public interface IDeleteMinuteUseCase
{
    public ICustomResult<bool> Handle(int id, int userId);
}