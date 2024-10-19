using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.UseCases;

public interface ICreateTimePeriodUseCase
{
    Task<Result<TimePeriodEntity>> Handle(CreateTimePeriodDto dto, int userId);
}