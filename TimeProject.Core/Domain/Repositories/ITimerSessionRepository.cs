using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface ITimerSessionRepository
{
    Task<TimerSessionEntity> Create(TimerSessionEntity entity);
    Task<TimerSessionEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimerSessionEntity entity);
}