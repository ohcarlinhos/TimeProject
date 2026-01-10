using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId);
}