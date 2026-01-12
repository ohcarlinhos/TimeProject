using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Minutes;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Minutes;

public interface ICreateMinuteByListUseCase
{
    ICustomResult<IList<IMinute>> Handle(ICreateMinuteListDto dto, int recordId, int userId);
}