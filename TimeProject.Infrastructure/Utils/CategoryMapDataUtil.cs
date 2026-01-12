using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Categories;

namespace TimeProject.Infrastructure.Utils;

public class CategoryMapDataUtil(IMapper mapper) : ICategoryMapDataUtil
{
    public IList<ICategoryOutDto> Handle(IList<ICategory> entities)
    {
        return mapper.Map<IList<ICategory>, IList<ICategoryOutDto>>(entities);
    }

    public ICategoryOutDto Handle(ICategory entity)
    {
        return mapper.Map<ICategory, ICategoryOutDto>(entity);
    }
}