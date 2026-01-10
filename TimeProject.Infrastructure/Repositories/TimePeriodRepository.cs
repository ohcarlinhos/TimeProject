using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class TimePeriodRepository(ProjectContext db) : ITimePeriodRepository
{
    public List<TimePeriodEntity> Index(int timeRecordId, int userId, PaginationQuery paginationQuery)
    {
        return db.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .OrderByDescending(tp => tp.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        return await db.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .CountAsync();
    }

    public async Task<TimePeriodEntity> Create(TimePeriodEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        db.TimePeriods.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entities)
    {
        var now = DateTime.Now.ToUniversalTime();

        foreach (var entity in entities)
        {
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
        }

        db.TimePeriods.AddRange(entities);
        await db.SaveChangesAsync();
        return entities;
    }

    public async Task<TimePeriodEntity> Update(TimePeriodEntity entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.TimePeriods.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(TimePeriodEntity entity)
    {
        db.TimePeriods.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByList(List<TimePeriodEntity> entityList)
    {
        db.TimePeriods.RemoveRange(entityList);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<TimePeriodEntity?> FindById(int id, int userId)
    {
        return await db.TimePeriods
            .FirstOrDefaultAsync(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}