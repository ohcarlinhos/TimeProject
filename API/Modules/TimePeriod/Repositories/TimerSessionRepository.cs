using API.Core.TimePeriod.Repositories;
using API.Database;
using Entities;

namespace API.Modules.TimePeriod.Repositories;

public class TimerSessionRepository(ProjectContext db) : ITimerSessionRepository
{
    public async Task<TimerSessionEntity> Create(TimerSessionEntity timerSessionEntity)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        timerSessionEntity.CreatedAt = now;
        timerSessionEntity.UpdatedAt = now;

        db.TimerSessions.Add(timerSessionEntity);

        await db.SaveChangesAsync();
        return timerSessionEntity;
    }
}