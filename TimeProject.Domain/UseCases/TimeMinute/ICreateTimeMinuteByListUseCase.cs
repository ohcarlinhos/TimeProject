using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeMinute;

public interface ICreateTimeMinuteByListUseCase
{
    ICustomResult<IList<IMinuteRecord>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId);
}