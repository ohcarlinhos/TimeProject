using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    ICustomResult<IPeriod> Handle(ICreatePeriodDto dto, int userId);
}