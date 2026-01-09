using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Utils;

public interface ICategoryMapDataUtil
{
    List<CategoryOutDto> Handle(List<CategoryEntity> entities);
}