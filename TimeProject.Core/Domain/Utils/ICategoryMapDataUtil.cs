using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Category;

namespace TimeProject.Core.Domain.Utils;

public interface ICategoryMapDataUtil
{
    List<CategoryOutDto> Handle(List<CategoryEntity> entities);
}