using Entities;

namespace Core.TimerSession;

public interface ITimerSessionRepository
{
    Task<TimerSessionEntity> Create(TimerSessionEntity entity);
    Task<TimerSessionEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimerSessionEntity entity);
}