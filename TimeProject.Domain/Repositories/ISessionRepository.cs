using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ISessionRepository
{
    ISession Create(ISession entity);
    ISession? FindById(int id, int userId);
    bool Delete(ISession entity);
}