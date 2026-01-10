using AutoMapper;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public IList<CategoryOutDto> Handle(IList<Category> entities)
    {
        return mapper.Map<IList<Category>, IList<CategoryOutDto>>(entities);
    }

    public CategoryOutDto Handle(Category entity)
    {
        return mapper.Map<Category, CategoryOutDto>(entity);
    }
}