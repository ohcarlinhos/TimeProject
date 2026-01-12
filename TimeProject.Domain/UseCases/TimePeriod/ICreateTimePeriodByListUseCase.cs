using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    ICustomResult<IList<IPeriod>> Handle(IPeriodListDto dto, int timeRecordId, int userId);
}