using API.Modules.Category.Entities;

namespace API.Modules.Category.Repositories;

public interface ICategoryRepository
{
    List<Entities.Category> Index(int userId);
    List<Entities.Category> Index(int userId, int page, int perPage, string search, string sort);
    Task<int> GetTotalItems(int userId, string search);
    Task<Entities.Category> Create(Entities.Category entity);
    Task<Entities.Category> Update(Entities.Category entity);
    Task<bool> Delete(Entities.Category entity);
    Task<Entities.Category?> FindById(int id);
    Task<Entities.Category?> FindById(int id, int userId);
    Task<Entities.Category?> FindByName(string name, int userId);
}