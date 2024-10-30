using Entities;
using Shared.Category;

namespace Core.Category.Utils;

public interface ICategoryMapDataUtil
{
    List<CategoryMap> Handle(List<CategoryEntity> entities);
}