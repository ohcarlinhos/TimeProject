using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface IUpdatePeriodUseCase
{
    ICustomResult<IPeriod> Handle(int id, IPeriodDto dto, int userId);
}