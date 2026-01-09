using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.UseCases.Category;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;

namespace TimeProject.Api.Modules.Category.UseCases;

public class UpdateCategoryUseCase(ICategoryRepository repo) : IUpdateCategoryUseCase
{
    public async Task<Result<CategoryEntity>> Handle(int id, CategoryDto dto, int userId)
    {
        var result = new Result<CategoryEntity>();
        var category = await repo.FindById(id);

        if (category == null) return result.SetError(CategoryMessageErrors.NotFound);

        if (category.UserId != userId) return result.SetError(GeneralMessageErrors.Unauthorized);

        if (await repo.FindByName(dto.Name, userId) != null)
            return result.SetError(CategoryMessageErrors.AlreadyExists);

        category.Name = dto.Name;
        result.Data = await repo.Update(category);
        return result;
    }
}