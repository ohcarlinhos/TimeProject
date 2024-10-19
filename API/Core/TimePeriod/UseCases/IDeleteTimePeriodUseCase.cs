using Shared.General;

namespace API.Core.TimePeriod.UseCases;

public interface IDeleteTimePeriodUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}