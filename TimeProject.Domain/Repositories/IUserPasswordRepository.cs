using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IUserPasswordRepository
{
    public Task<bool> Create(UserPassword entity);
    public Task<bool> Update(UserPassword entity);
    public Task<bool> Delete(int id);
    public Task<UserPassword?> FindByUserId(int userId);
}