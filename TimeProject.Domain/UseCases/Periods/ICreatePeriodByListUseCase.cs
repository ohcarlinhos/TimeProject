using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface ICreatePeriodByListUseCase
{
    ICustomResult<IList<IPeriod>> Handle(IPeriodListDto dto, int recordId, int userId);
}