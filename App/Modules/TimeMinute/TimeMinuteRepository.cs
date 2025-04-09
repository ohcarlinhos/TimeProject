using App.Database;
using Core.TimeMinute;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.TimeMinute;

public class TimeMinuteRepository(ProjectContext db) : ITimeMinuteRepository
{
    public async Task<TimeMinuteEntity> Create(TimeMinuteEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.TimeMinutes.Add(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TimeMinuteEntity>> CreateByList(List<TimeMinuteEntity> entities)
    {
        var now = DateTime.Now.ToUniversalTime();

        foreach (var entity in entities)
        {
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
        }

        db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        db.TimeMinutes.AddRange(entities);

        await db.SaveChangesAsync();
        return entities;
    }

    public Task<TimeMinuteEntity?> FindById(int id, int userId)
    {
        return db.TimeMinutes.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    }

    public async Task<bool> Delete(TimeMinuteEntity entity)
    {
        db.TimeMinutes.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}