using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.Category;

public interface IUpdateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(int id, CategoryDto dto, int userId);
}