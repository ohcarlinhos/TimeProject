using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId);
}