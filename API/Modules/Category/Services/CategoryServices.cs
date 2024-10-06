using System.Security.Claims;
using API.Modules.Category.Repositories;
using API.Modules.Core;
using AutoMapper;
using Entities;
using Shared;
using Shared.Category;
using Shared.General;
using Shared.General.Util;

namespace API.Modules.Category.Services;

public class CategoryServices(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryServices
{
    public Result<List<CategoryMap>> Index(ClaimsPrincipal user, bool onlyWithData)
    {
        return new Result<List<CategoryMap>>()
            { Data = MapData(categoryRepository.Index(UserClaims.Id(user), onlyWithData)) };
    }

    public async Task<Result<Pagination<CategoryMap>>> Index(PaginationQuery paginationQuery, ClaimsPrincipal user)
    {
        var data = MapData(categoryRepository.Index(paginationQuery, UserClaims.Id(user)));
        var totalItems = await categoryRepository.GetTotalItems(paginationQuery, UserClaims.Id(user));
        return new Result<Pagination<CategoryMap>>()
            { Data = Pagination<CategoryMap>.Handle(data, paginationQuery, totalItems) };
    }

    public async Task<Result<CategoryEntity>> Create(CategoryDto dto, ClaimsPrincipal user)
    {
        var result = new Result<CategoryEntity>();
        var category = await categoryRepository.FindByName(dto.Name, UserClaims.Id(user));

        if (category != null)
            return result.SetData(category);

        result.Data = await categoryRepository.Create(new CategoryEntity
        {
            UserId = UserClaims.Id(user),
            Name = dto.Name
        });
        return result;
    }

    public async Task<Result<CategoryEntity>> Update(int id, CategoryDto dto, ClaimsPrincipal user)
    {
        var result = new Result<CategoryEntity>();
        var category = await categoryRepository.FindById(id);

        if (category == null) return result.SetError("not_found: Categoria não encontrada.");

        if (category.UserId != UserClaims.Id(user)) return result.SetError("unauthorized");

        if (await categoryRepository.FindByName(dto.Name, UserClaims.Id(user)) != null)
            return result.SetError($"bad_request: Você já possui uma category '{dto.Name}'.");

        category.Name = dto.Name;
        result.Data = await categoryRepository.Update(category);
        return result;
    }

    public async Task<Result<bool>> Delete(int id, ClaimsPrincipal user)
    {
        var result = new Result<bool>();
        var category = await categoryRepository.FindById(id);

        if (category == null) return result.SetError("not_found: Categoria não encontrada.");

        if (category.UserId != UserClaims.Id(user)) return result.SetError("unauthorized");

        result.Data = await categoryRepository.Delete(category);
        return result;
    }
    
    private CategoryMap MapData(CategoryEntity entity)
    {
        return mapper.Map<CategoryEntity, CategoryMap>(entity);
    }
    
    private List<CategoryMap> MapData(List<CategoryEntity> entities)
    {
        return mapper.Map<List<CategoryEntity>, List<CategoryMap>>(entities);
    }
}