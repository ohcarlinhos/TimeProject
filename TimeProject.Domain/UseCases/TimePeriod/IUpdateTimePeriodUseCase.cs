using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IUpdateTimePeriodUseCase
{
    ICustomResult<IPeriod> Handle(int id, IPeriodDto dto, int userId);
}