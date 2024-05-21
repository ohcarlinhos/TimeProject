using API.Modules.Category.DTO;
using API.Modules.Category.Entities;
using API.Modules.Category.Models;
using API.Modules.Category.Repositories;
using API.Modules.Shared;
using AutoMapper;

namespace API.Modules.Category.Services;

public class CategoryServices(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryServices
{
    private CategoryDto MapData(Entities.Category entity)
    {
        return mapper.Map<Entities.Category, CategoryDto>(entity);
    }
    
    private List<CategoryDto> MapData(List<Entities.Category> entities)
    {
        return mapper.Map<List<Entities.Category>, List<CategoryDto>>(entities);
    }

    public Result<List<CategoryDto>> Index(int userId)
    {
        return new Result<List<CategoryDto>>()
            { Data = MapData(categoryRepository.Index(userId)) };
    }

    public async Task<Result<Pagination<CategoryDto>>> Index(int userId, int page, int perPage, string search, string sort)
    {
        var data = MapData(categoryRepository.Index(userId, page, perPage, search, sort));
        var totalItems = await categoryRepository.GetTotalItems(userId, search);
        return new Result<Pagination<CategoryDto>>()
            { Data = Pagination<CategoryDto>.Handle(data, page, perPage, totalItems, search, "", sort) };
    }

    public async Task<Result<Entities.Category>> Create(CategoryModel model, int userId)
    {
        var result = new Result<Entities.Category>();
        var category = await categoryRepository.FindByName(model.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = await categoryRepository.Create(new Entities.Category
        {
            UserId = userId,
            Name = model.Name
        });
        return result;
    }

    public async Task<Result<Entities.Category>> Update(int id, CategoryModel model, int userId)
    {
        var result = new Result<Entities.Category>();
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