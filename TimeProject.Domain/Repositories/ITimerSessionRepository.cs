using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimerSessionRepository
{
    Task<TimerSession> Create(TimerSession entity);
    Task<TimerSession?> FindById(int id, int userId);
    Task<bool> Delete(TimerSession entity);
}