using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeMinute;

public interface IDeleteTimeMinuteUseCase
{
    public Task<Result<bool>> Handle(int id, int userId);
}