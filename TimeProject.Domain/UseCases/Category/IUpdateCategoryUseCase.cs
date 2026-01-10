using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IUpdateCategoryUseCase
{
    Task<ICustomResult<Entities.Category>> Handle(int id, ICategoryDto dto, int userId);
}