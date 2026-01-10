using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    Task<Result<List<TimePeriodEntity>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}