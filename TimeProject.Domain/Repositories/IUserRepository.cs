using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface IUserRepository
{
    List<User> Index(PaginationQuery paginationQuery);
    int GetTotalItems(PaginationQuery paginationQuery);
    Task<User> Create(User entity);
    Task<User> Update(User entity);
    Task<bool> Delete(int id);
    Task<User?> FindById(int id);
    Task<User?> FindByEmail(string email);
    Task<bool> EmailIsAvailable(string email);
}