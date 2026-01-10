using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Utils;

public interface ICategoryMapDataUtil
{
    List<CategoryOutDto> Handle(List<CategoryEntity> entities);
}