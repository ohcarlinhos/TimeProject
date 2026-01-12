using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Minute;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeMinute;

public interface ICreateTimeMinuteByListUseCase
{
    ICustomResult<IList<IMinute>> Handle(ICreateMinuteListDto dto, int timeRecordId, int userId);
}