using Shared;
using Shared.General;

namespace API.Modules.Category.Repositories;

public interface ICategoryRepository
{
    List<Entities.Category> Index(int userId);
    List<Entities.Category> Index(PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId);
    Task<Entities.Category> Create(Entities.Category entity);
    Task<Entities.Category> Update(Entities.Category entity);
    Task<bool> Delete(Entities.Category entity);
    Task<Entities.Category?> FindById(int id);
    Task<Entities.Category?> FindById(int id, int userId);
    Task<Entities.Category?> FindByName(string name, int userId);
}