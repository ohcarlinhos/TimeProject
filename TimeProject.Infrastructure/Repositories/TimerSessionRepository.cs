using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class TimerSessionRepository(ProjectContext db) : ITimerSessionRepository
{
    public async Task<TimerSession> Create(TimerSession entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.TimerSessions.Add(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public Task<TimerSession?> FindById(int id, int userId)
    {
        return db.TimerSessions
            .Include(e => e.PeriodRecords)
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    }

    public async Task<bool> Delete(TimerSession entity)
    {
        db.TimerSessions.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}