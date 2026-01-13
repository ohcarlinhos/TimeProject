using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface IUpdatePeriodUseCase
{
    ICustomResult<IPeriod> Handle(int id, IPeriodData data, int userId);
}