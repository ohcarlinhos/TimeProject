using Entities;

namespace Core.TimerSession;

public interface ITimerSessionRepository
{
    Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity);
    Task<TimerSessionEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimerSessionEntity entity);
}