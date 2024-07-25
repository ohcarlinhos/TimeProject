using API.Modules.Category.Dto;
using API.Modules.Category.Map;
using API.Modules.Category.Repositories;
using API.Modules.Shared;
using AutoMapper;

namespace API.Modules.Category.Services;

public class CategoryServices(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryServices
{
    private CategoryMap MapData(Entities.Category entity)
    {
        return mapper.Map<Entities.Category, CategoryMap>(entity);
    }
    
    private List<CategoryMap> MapData(List<Entities.Category> entities)
    {
        return mapper.Map<List<Entities.Category>, List<CategoryMap>>(entities);
    }

    public Result<List<CategoryMap>> Index(int userId)
    {
        return new Result<List<CategoryMap>>()
            { Data = MapData(categoryRepository.Index(userId)) };
    }

    public async Task<Result<Pagination<CategoryMap>>> Index(int userId, int page, int perPage, string search, string sort)
    {
        var data = MapData(categoryRepository.Index(userId, page, perPage, search, sort));
        var totalItems = await categoryRepository.GetTotalItems(userId, search);
        return new Result<Pagination<CategoryMap>>()
            { Data = Pagination<CategoryMap>.Handle(data, page, perPage, totalItems, search, "", sort) };
    }

    public async Task<Result<Entities.Category>> Create(CategoryDto dto, int userId)
    {
        var result = new Result<Entities.Category>();
        var category = await categoryRepository.FindByName(dto.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = await categoryRepository.Create(new Entities.Category
        {
            UserId = userId,
            Name = dto.Name
        });
        return result;
    }

    public async Task<Result<Entities.Category>> Update(int id, CategoryDto dto, int userId)
    {
        var result = new Result<Entities.Category>();
        var category = await categoryRepository.FindById(id);

        if (category == null) return result.SetError("not_found: Categoria não encontrada.");

        if (category.UserId != userId) return result.SetError("unauthorized");

        if (await categoryRepository.FindByName(dto.Name, userId) != null)
            return result.SetError($"bad_request: Você já possui uma category '{dto.Name}'.");

        category.Name = dto.Name;
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