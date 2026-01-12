using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class DeleteCategoryUseCase(ICategoryRepository repo) : IDeleteCategoryUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var category = repo.FindById(id);

        if (category == null) return result.SetError(CategoryMessageErrors.NotFound);

        if (category.UserId != userId) return result.SetError(GeneralMessageErrors.Unauthorized);

        result.Data = repo.Delete(category);
        return result;
    }
}