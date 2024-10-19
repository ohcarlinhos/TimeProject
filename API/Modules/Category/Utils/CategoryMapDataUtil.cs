using API.Core.Category.Utils;
using API.Core.User.Utils;
using AutoMapper;
using Entities;
using Shared.Category;

namespace API.Modules.Category.Utils;

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