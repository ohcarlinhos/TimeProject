using API.Database;
using Entities;

namespace API.Modules.TimePeriod.Services;

public class TimerSessionServices(ProjectContext dbContext) : ITimerSessionServices
{
    public async Task<TimerSession> Create(TimerSession timerSession)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        timerSession.CreatedAt = now;
        timerSession.UpdatedAt = now;

        dbContext.TimerSessions.Add(timerSession);

        await dbContext.SaveChangesAsync();
        return timerSession;
    }
}