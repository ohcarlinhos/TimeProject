using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimePeriod;

public interface ICreateTimePeriodByListUseCase
{
    Task<Result<List<Entities.PeriodRecord>>> Handle(TimePeriodListDto dto, int timeRecordId, int userId);
}