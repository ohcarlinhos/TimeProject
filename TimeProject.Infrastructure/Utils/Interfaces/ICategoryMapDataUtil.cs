using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface ICategoryMapDataUtil
{
    IList<ICategoryOutDto> Handle(IList<ICategory> entities);
}