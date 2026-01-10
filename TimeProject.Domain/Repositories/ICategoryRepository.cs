using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ICategoryRepository
{
    IList<Category> Index(int userId, bool onlyWithData);
    IList<Category> Index(IPaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(IPaginationQuery paginationQuery, int userId);
    Task<Category> Create(Category entity);
    Task<Category> Update(Category entity);
    Task<bool> Delete(Category entity);
    Task<Category?> FindById(int id);
    Task<Category?> FindById(int id, int userId);
    Task<Category?> FindByName(string name, int userId);
}