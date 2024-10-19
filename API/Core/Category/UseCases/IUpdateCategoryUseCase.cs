using Entities;
using Shared.Category;
using Shared.General;

namespace API.Core.Category.UseCases;

public interface IUpdateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(int id, CategoryDto dto, int userId);
}