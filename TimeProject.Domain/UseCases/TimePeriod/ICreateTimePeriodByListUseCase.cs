using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    Task<ICustomResult<IList<PeriodRecord>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}