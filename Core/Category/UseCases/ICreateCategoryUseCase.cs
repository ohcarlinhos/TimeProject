using Entities;
using Shared.Category;
using Shared.General;

namespace Core.Category.UseCases;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId);
}