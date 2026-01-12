using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;

namespace TimeProject.Domain.Utils;

public interface ICategoryMapDataUtil
{
    IList<ICategoryOutDto> Handle(IList<ICategory> entities);
}