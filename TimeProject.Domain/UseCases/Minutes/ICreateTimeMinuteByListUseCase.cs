using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Minute;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Minutes;

public interface ICreateTimeMinuteByListUseCase
{
    ICustomResult<IList<IMinute>> Handle(ICreateMinuteListDto dto, int timeRecordId, int userId);
}