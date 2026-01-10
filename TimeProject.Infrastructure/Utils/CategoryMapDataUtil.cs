using AutoMapper;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Infrastructure.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public List<CategoryOutDto> Handle(List<CategoryEntity> entities)
    {
        return mapper.Map<List<CategoryEntity>, List<CategoryOutDto>>(entities);
    }

    public CategoryOutDto Handle(CategoryEntity entity)
    {
        return mapper.Map<CategoryEntity, CategoryOutDto>(entity);
    }
}