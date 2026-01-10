using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeMinute;

public interface ICreateTimeMinuteByListUseCase
{
    Task<Result<List<TimeMinuteEntity>>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId);
}