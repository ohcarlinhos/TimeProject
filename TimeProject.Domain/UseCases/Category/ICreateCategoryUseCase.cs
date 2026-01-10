using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId);
}