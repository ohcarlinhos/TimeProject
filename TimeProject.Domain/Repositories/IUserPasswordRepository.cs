using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IUserPasswordRepository
{
    public bool Create(IUserPassword entity);
    public bool Update(IUserPassword entity);
    public bool Delete(int id);
    public IUserPassword? FindByUserId(int userId);
}