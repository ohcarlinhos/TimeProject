using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IUpdateTimePeriodUseCase
{
    Task<ICustomResult<PeriodRecord>> Handle(int id, TimePeriodDto dto, int userId);
}