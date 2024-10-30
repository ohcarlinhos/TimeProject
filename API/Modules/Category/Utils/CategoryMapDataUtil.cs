using Core.User.Utils;
using AutoMapper;
using Core.Category.Utils;
using Entities;
using Shared.Category;

namespace App.Modules.Category.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public CategoryMap Handle(CategoryEntity entity)
    {
        return mapper.Map<CategoryEntity, CategoryMap>(entity);
    }

    public List<CategoryMap> Handle(List<CategoryEntity> entities)
    {
        return mapper.Map<List<CategoryEntity>, List<CategoryMap>>(entities);
    }
}