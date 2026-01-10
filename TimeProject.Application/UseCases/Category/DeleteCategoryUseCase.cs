using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class DeleteCategoryUseCase(ICategoryRepository repo) : IDeleteCategoryUseCase
{
    public async Task<IResult<bool>> Handle(int id, int userId)
    {
        var result = new Result<bool>();
        var category = await repo.FindById(id);

        if (category == null) return result.SetError(CategoryMessageErrors.NotFound);

        if (category.UserId != userId) return result.SetError(GeneralMessageErrors.Unauthorized);

        result.Data = await repo.Delete(category);
        return result;
    }
}