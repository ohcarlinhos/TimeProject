using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(CreateTimePeriodDto dto, int userId);
}