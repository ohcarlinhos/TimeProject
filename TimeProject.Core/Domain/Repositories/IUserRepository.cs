using TimeProject.Core.RemoveDependencies.General.Pagination;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface IUserRepository
{
    List<UserEntity> Index(PaginationQuery paginationQuery);
    int GetTotalItems(PaginationQuery paginationQuery);
    Task<UserEntity> Create(UserEntity entity);
    Task<UserEntity> Update(UserEntity entity);
    Task<bool> Delete(int id);
    Task<UserEntity?> FindById(int id);
    Task<UserEntity?> FindByEmail(string email);
    Task<bool> EmailIsAvailable(string email);
}