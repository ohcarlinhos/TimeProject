using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IUpdateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(int id, CategoryDto dto, int userId);
}