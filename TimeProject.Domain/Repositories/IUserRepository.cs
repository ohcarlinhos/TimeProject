using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface IUserRepository
{
    IList<IUser> Index(IPaginationQuery paginationQuery);
    int GetTotalItems(IPaginationQuery paginationQuery);
    IUser Create(IUser entity);
    IUser Update(IUser entity);
    bool Delete(int id);
    IUser? FindById(int id);
    IUser? FindByEmail(string email);
    bool EmailIsAvailable(string email);
}