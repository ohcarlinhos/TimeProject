using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface IDeletePeriodUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}