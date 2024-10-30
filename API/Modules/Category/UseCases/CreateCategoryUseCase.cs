using Core.Category;
using Core.Category.UseCases;
using Entities;
using Shared.Category;
using Shared.General;

namespace API.Modules.Category.UseCases;

public class CreateCategoryUseCase(ICategoryRepository repo) : ICreateCategoryUseCase
{
    public async Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId)
    {
        var result = new Result<CategoryEntity>();
        var category = await repo.FindByName(dto.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = await repo.Create(new CategoryEntity
        {
            UserId = userId,
            Name = dto.Name
        });
        return result;
    }
}