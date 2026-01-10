using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeMinute;

public interface IDeleteTimeMinuteUseCase
{
    public Task<ICustomResult<bool>> Handle(int id, int userId);
}