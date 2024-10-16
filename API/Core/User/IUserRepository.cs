using Entities;
using Shared.General.Pagination;

namespace API.Core.User
{
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
}