using API.Modules.User.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> Create(UserEntity entity);
        Task<UserEntity> Update(UserEntity entity);
        Task<bool> Delete(int id);
        Task<UserEntity?> FindById(int id);
        Task<UserEntity?> FindByEmail(string email);
    }
}