using API.Modules.Category.DTO;
using API.Modules.Category.Entities;
using API.Modules.Category.Models;
using API.Modules.Shared;

namespace API.Modules.Category.Services;

public interface ICategoryServices
{
    Result<List<CategoryDto>> Index(int userId);
    Task<Result<Pagination<CategoryDto>>> Index(int userId, int page, int perPage);
    Task<Result<CategoryEntity>> Create(CategoryModel model, int userId);
    Task<Result<CategoryEntity>> Update(int id, CategoryModel model, int userId);
    Task<Result<bool>> Delete(int id, int userId);
}