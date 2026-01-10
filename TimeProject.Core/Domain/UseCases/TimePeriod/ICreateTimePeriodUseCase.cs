using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(CreateTimePeriodDto dto, int userId);
}