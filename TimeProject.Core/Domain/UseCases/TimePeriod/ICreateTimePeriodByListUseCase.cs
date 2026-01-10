using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    Task<Result<List<TimePeriodEntity>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}