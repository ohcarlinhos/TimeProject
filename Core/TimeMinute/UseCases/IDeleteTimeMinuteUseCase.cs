using Shared.General;

namespace Core.TimeMinute.UseCases;

public interface IDeleteTimeMinuteUseCase
{
    public Task<Result<bool>> Handle(int id, int userId);
}