using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    Task<ICustomResult<PeriodRecord>> Handle(CreateTimePeriodDto dto, int userId);
}