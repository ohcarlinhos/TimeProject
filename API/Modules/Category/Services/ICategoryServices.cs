using System.Security.Claims;
using Entities;
using Shared;
using Shared.Category;
using Shared.General;

namespace API.Modules.Category.Services;

public interface ICategoryServices
{
    Result<List<CategoryMap>> Index(ClaimsPrincipal user);
    Task<Result<Pagination<CategoryMap>>> Index(PaginationQuery paginationQuery, ClaimsPrincipal user);
    Task<Result<CategoryEntity>> Create(CategoryDto dto, ClaimsPrincipal user);
    Task<Result<CategoryEntity>> Update(int id, CategoryDto dto, ClaimsPrincipal user);
    Task<Result<bool>> Delete(int id, ClaimsPrincipal user);
}