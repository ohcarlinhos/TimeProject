using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
namespace TimeProject.Api.Modules.TimerSession;

public class TimerSessionRepository(ProjectContext db) : ITimerSessionRepository
{
    public async Task<TimerSessionEntity> Create(TimerSessionEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.TimerSessions.Add(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public Task<TimerSessionEntity?> FindById(int id, int userId)
    {
        return db.TimerSessions
            .Include(e => e.TimePeriods)
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    }

    public async Task<bool> Delete(TimerSessionEntity entity)
    {
        db.TimerSessions.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}