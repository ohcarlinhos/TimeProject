using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface ICreatePeriodUseCase
{
    ICustomResult<IPeriod> Handle(ICreatePeriodDto dto, int userId);
}