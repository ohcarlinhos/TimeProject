using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IUpdateTimePeriodUseCase
{
    ICustomResult<IPeriodRecord> Handle(int id, TimePeriodDto dto, int userId);
}