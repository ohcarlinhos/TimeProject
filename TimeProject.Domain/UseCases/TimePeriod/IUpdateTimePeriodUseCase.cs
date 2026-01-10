using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface IUpdateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(int id, TimePeriodDto dto, int userId);
}