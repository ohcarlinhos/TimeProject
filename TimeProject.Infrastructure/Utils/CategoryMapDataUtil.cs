using AutoMapper;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Entities;

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