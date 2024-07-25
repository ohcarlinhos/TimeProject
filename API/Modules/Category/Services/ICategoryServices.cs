using API.Modules.Category.Dto;
using API.Modules.Category.Map;
using API.Modules.Shared;

namespace API.Modules.Category.Services;

public interface ICategoryServices
{
    Result<List<CategoryMap>> Index(int userId);
    Task<Result<Pagination<CategoryMap>>> Index(int userId, int page, int perPage, string search, string sort);
    Task<Result<Entities.Category>> Create(CategoryDto dto, int userId);
    Task<Result<Entities.Category>> Update(int id, CategoryDto dto, int userId);
    Task<Result<bool>> Delete(int id, int userId);
}