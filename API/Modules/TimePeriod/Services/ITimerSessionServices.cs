using Entities;

namespace API.Modules.TimePeriod.Services;

public interface ITimerSessionServices
{
    public Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity);
}