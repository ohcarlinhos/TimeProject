using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.UseCases;

public interface ICreateTimePeriodByListUseCase
{
    Task<Result<List<TimePeriodEntity>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}