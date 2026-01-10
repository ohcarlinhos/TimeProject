using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface IUpdateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(int id, TimePeriodDto dto, int userId);
}