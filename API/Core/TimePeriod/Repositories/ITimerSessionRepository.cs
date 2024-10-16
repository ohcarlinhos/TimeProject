using Entities;

namespace API.Core.TimePeriod.Repositories;

public interface ITimerSessionRepository
{
    public Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity);
}