using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface IDeleteTimePeriodUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}