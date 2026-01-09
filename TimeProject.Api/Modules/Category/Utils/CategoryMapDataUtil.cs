using AutoMapper;
using Core.Category.Utils;
using Entities;
using Shared.Category;

namespace TimeProject.Api.Modules.Category.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public List<CategoryMap> Handle(List<CategoryEntity> entities)
    {
        return mapper.Map<List<CategoryEntity>, List<CategoryMap>>(entities);
    }

    public CategoryMap Handle(CategoryEntity entity)
    {
        return mapper.Map<CategoryEntity, CategoryMap>(entity);
    }
}