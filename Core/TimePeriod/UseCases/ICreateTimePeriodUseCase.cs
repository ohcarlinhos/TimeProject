using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace Core.TimePeriod.UseCases;

public interface ICreateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(CreateTimePeriodDto dto, int userId);
}