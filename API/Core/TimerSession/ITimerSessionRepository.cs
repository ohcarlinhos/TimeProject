using Entities;

namespace API.Core.TimerSession;

public interface ITimerSessionRepository
{
    public Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity);
}