using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimerSessionRepository
{
    Task<TimerSessionEntity> Create(TimerSessionEntity entity);
    Task<TimerSessionEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimerSessionEntity entity);
}