using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class UpdateCategoryUseCase(ICategoryRepository repo) : IUpdateCategoryUseCase
{
    public ICustomResult<ICategory> Handle(int id, ICategoryDto dto, int userId)
    {
        var result = new CustomResult<ICategory>();
        var category = repo.FindById(id);

        if (category == null) return result.SetError(CategoryMessageErrors.NotFound);

        if (category.UserId != userId) return result.SetError(GeneralMessageErrors.Unauthorized);

        if (repo.FindByName(dto.Name, userId) != null)
            return result.SetError(CategoryMessageErrors.AlreadyExists);

        category.Name = dto.Name;
        result.Data = repo.Update(category);
        return result;
    }
}