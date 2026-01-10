using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class UpdateCategoryUseCase(ICategoryRepository repo) : IUpdateCategoryUseCase
{
    public async Task<ICustomResult<Domain.Entities.Category>> Handle(int id, ICategoryDto dto, int userId)
    {
        var result = new CustomResult<Domain.Entities.Category>();
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