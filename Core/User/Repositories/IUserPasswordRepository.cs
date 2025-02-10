using Entities;

namespace Core.User.Repositories;

public interface IUserPasswordRepository
{
    public Task<bool> Create(UserPasswordEntity entity);
    public Task<bool> Update(UserPasswordEntity entity);
    public Task<bool> Delete(int id);
    public Task<UserPasswordEntity?> FindByUserId(int userId);
}