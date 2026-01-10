using TimeProject.Core.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Shared;

namespace TimeProject.Core.Domain.UseCases.TimeMinute;

public interface ICreateTimeMinuteByListUseCase
{
    Task<Result<List<TimeMinuteEntity>>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId);
}