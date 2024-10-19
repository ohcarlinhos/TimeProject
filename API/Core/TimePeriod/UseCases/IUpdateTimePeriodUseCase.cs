using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.UseCases;

public interface IUpdateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(int id, TimePeriodDto dto, int userId);
}