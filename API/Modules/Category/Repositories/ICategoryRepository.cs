using API.Modules.Category.Entities;

namespace API.Modules.Category.Repositories;

public interface ICategoryRepository
{
    List<CategoryEntity> Index(int userId);
    List<CategoryEntity> Index(int userId, int page, int perPage, string search, string sort);
    Task<int> GetTotalItems(int userId, string search);
    Task<CategoryEntity> Create(CategoryEntity entity);
    Task<CategoryEntity> Update(CategoryEntity entity);
    Task<bool> Delete(CategoryEntity entity);
    Task<CategoryEntity?> FindById(int id);
    Task<CategoryEntity?> FindById(int id, int userId);
    Task<CategoryEntity?> FindByName(string name, int userId);
}