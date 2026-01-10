using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Entities;

namespace TimeProject.Application.UseCases.Category;

public class CreateCategoryUseCase(ICategoryRepository repo) : ICreateCategoryUseCase
{
    public async Task<Result<Domain.Entities.Category>> Handle(CategoryDto dto, int userId)
    {
        var result = new Result<Domain.Entities.Category>();
        var category = await repo.FindByName(dto.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = await repo.Create(new Domain.Entities.Category
        {
            UserId = userId,
            Name = dto.Name
        });
        return result;
    }
}