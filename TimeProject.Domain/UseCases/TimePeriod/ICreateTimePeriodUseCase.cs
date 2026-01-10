using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    Task<Result<Entities.PeriodRecord>> Handle(CreateTimePeriodDto dto, int userId);
}