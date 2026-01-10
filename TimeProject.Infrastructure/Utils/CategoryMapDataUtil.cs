using AutoMapper;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public List<CategoryOutDto> Handle(List<Category> entities)
    {
        return mapper.Map<List<Category>, List<CategoryOutDto>>(entities);
    }

    public CategoryOutDto Handle(Category entity)
    {
        return mapper.Map<Category, CategoryOutDto>(entity);
    }
}