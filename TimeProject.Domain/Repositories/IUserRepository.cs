using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface IUserRepository
{
    IList<User> Index(IPaginationQuery paginationQuery);
    int GetTotalItems(IPaginationQuery paginationQuery);
    Task<User> Create(User entity);
    Task<User> Update(User entity);
    Task<bool> Delete(int id);
    Task<User?> FindById(int id);
    Task<User?> FindByEmail(string email);
    Task<bool> EmailIsAvailable(string email);
}