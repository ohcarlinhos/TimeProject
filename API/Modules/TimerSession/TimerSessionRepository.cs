using Core.TimerSession;
using App.Database;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TimerSession;

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

    public Task<TimerSessionEntity?> FindById(int id, int userId)
    {
        return db.TimerSessions
            .Include(e => e.TimePeriods)
            .FirstOrDefaultAsync((e) => e.Id == id && e.UserId == userId);
    }

    public async Task<bool> Delete(TimerSessionEntity entity)
    {
        db.TimerSessions.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}