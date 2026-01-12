using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimerSessionRepository
{
    ISession Create(ISession entity);
    ISession? FindById(int id, int userId);
    bool Delete(ISession entity);
}