using Entities;
using Shared.General.Pagination;

namespace API.Core.Category;

public interface ICategoryRepository
{
    List<CategoryEntity> Index(int userId, bool onlyWithData);
    List<CategoryEntity> Index(PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId);
    Task<CategoryEntity> Create(CategoryEntity entity);
    Task<CategoryEntity> Update(CategoryEntity entity);
    Task<bool> Delete(CategoryEntity entity);
    Task<CategoryEntity?> FindById(int id);
    Task<CategoryEntity?> FindById(int id, int userId);
    Task<CategoryEntity?> FindByName(string name, int userId);
}