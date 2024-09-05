using API.Database;
using Entities;

namespace API.Modules.TimePeriod.Services;

public class TimerSessionServices(ProjectContext dbContext) : ITimerSessionServices
{
    public async Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        timerSessionEntity.CreatedAt = now;
        timerSessionEntity.UpdatedAt = now;

        dbContext.TimerSessions.Add(timerSessionEntity);

        await dbContext.SaveChangesAsync();
        return timerSessionEntity;
    }
}