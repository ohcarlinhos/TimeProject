using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    ICustomResult<IList<IPeriodRecord>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}