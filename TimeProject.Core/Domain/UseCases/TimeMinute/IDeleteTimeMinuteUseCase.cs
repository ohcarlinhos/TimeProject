using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimeMinute;

public interface IDeleteTimeMinuteUseCase
{
    public Task<Result<bool>> Handle(int id, int userId);
}