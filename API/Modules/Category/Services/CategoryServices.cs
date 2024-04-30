using API.Modules.Category.Entities;
using API.Modules.Category.Models;
using API.Modules.Category.Repositories;
using API.Modules.Shared;

namespace API.Modules.Category.Services;

public class CategoryServices(ICategoryRepository categoryRepository) : ICategoryServices
{
    public Result<List<CategoryEntity>> Index(int userId, int page, int perPage)
    {
        return new Result<List<CategoryEntity>>() { Data = categoryRepository.Index(userId) };
    }

    public async Task<Result<CategoryEntity>> Create(CategoryModel model, int userId)
    {
        var result = new Result<CategoryEntity>();
        var category = await categoryRepository.FindByName(model.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = await categoryRepository.Create(new CategoryEntity
        {
            UserId = userId,
            Name = model.Name
        });
        return result;
    }

    public async Task<Result<CategoryEntity>> Update(int id, CategoryModel model, int userId)
    {
        var result = new Result<CategoryEntity>();
        var category = await categoryRepository.FindById(id);

        if (category == null) return result.SetError("not_found: Categoria não encontrada.");

        if (category.UserId != userId) return result.SetError("unauthorized");

        if (await categoryRepository.FindByName(model.Name, userId) != null)
            return result.SetError($"bad_request: Você já possui uma category '{model.Name}'.");

        category.Name = model.Name;
        result.Data = await categoryRepository.Update(category);
        return result;
    }

    public async Task<Result<bool>> Delete(int id, int userId)
    {
        var result = new Result<bool>();
        var category = await categoryRepository.FindById(id);

        if (category == null) return result.SetError("not_found: Categoria não encontrada.");

        if (category.UserId != userId) return result.SetError("unauthorized");

        result.Data = await categoryRepository.Delete(category);
        return result;
    }
}