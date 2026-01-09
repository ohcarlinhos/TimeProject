using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Category;

namespace TimeProject.Api.Modules.Category.UseCases;

public class DeleteCategoryUseCase(ICategoryRepository repo) : IDeleteCategoryUseCase
{
    public async Task<Result<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var category = await repo.FindById(id);

        if (category == null) return result.SetError(CategoryMessageErrors.NotFound);

        if (category.UserId != userId) return result.SetError(GeneralMessageErrors.Unauthorized);

        result.Data = await repo.Delete(category);
        return result;
    }
}