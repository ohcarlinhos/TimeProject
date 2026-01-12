using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IDeleteTimePeriodUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}