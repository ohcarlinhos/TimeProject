using Entities;

namespace API.Modules.TimePeriod.Services;

public interface ITimerSessionServices
{
    public Task<TimerSession> Create(TimerSession timerSession);
}