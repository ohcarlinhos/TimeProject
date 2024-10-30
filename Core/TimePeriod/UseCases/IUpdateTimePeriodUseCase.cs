using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace Core.TimePeriod.UseCases;

public interface IUpdateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(int id, TimePeriodDto dto, int userId);
}