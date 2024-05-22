using API.Modules.Category.DTO;
using API.Modules.Category.Models;
using API.Modules.Shared;

namespace API.Modules.Category.Services;

public interface ICategoryServices
{
    Result<List<CategoryDto>> Index(int userId);
    Task<Result<Pagination<CategoryDto>>> Index(int userId, int page, int perPage, string search, string sort);
    Task<Result<Entities.Category>> Create(CategoryModel model, int userId);
    Task<Result<Entities.Category>> Update(int id, CategoryModel model, int userId);
    Task<Result<bool>> Delete(int id, int userId);
}