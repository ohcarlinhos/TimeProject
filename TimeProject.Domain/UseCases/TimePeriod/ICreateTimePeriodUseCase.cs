using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    ICustomResult<IPeriodRecord> Handle(CreateTimePeriodDto dto, int userId);
}