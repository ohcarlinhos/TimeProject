using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Entities;

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