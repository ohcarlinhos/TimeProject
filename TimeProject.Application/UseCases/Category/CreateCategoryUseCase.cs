using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Category;

namespace TimeProject.Application.UseCases.Category;

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