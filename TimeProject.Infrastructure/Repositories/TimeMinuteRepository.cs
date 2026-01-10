using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class TimeMinuteRepository(ProjectContext db) : ITimeMinuteRepository
{
    public async Task<MinuteRecord> Create(MinuteRecord entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.TimeMinutes.Add(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<List<MinuteRecord>> CreateByList(List<MinuteRecord> entities)
    {
        var now = DateTime.Now.ToUniversalTime();

        foreach (var entity in entities)
        {
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
        }

        db.TimeMinutes.AddRange(entities);

        await db.SaveChangesAsync();
        return entities;
    }

    public Task<MinuteRecord?> FindById(int id, int userId)
    {
        return db.TimeMinutes.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    }

    public async Task<bool> Delete(MinuteRecord entity)
    {
        db.TimeMinutes.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}