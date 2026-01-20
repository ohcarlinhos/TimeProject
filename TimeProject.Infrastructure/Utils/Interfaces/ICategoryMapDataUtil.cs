using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Categories;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface ICategoryMapDataUtil
{
    IList<ICategoryOutDto> Handle(IList<ICategory> entities);
    ICategoryOutDto Handle(ICategory entity);
}