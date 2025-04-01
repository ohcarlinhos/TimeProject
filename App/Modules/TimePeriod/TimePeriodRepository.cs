using Core.TimePeriod;
using App.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Pagination;

namespace App.Modules.TimePeriod;

public class TimePeriodRepository(ProjectContext dbContext) : ITimePeriodRepository
{
    public List<TimePeriodEntity> Index(int timeRecordId, int userId, PaginationQuery paginationQuery)
    {
        return dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .OrderByDescending(tp => tp.Start)
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId)
    {
        return await dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .CountAsync();
    }

    public async Task<TimePeriodEntity> Create(TimePeriodEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.TimePeriods.Add(entity);
        await dbContext.SaveChangesAsync();
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

        dbContext.TimePeriods.AddRange(entities);
        await dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task<TimePeriodEntity> Update(TimePeriodEntity entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.TimePeriods.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(TimePeriodEntity entity)
    {
        dbContext.TimePeriods.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByList(List<TimePeriodEntity> entityList)
    {
        dbContext.TimePeriods.RemoveRange(entityList);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TimePeriodEntity?> FindById(int id, int userId)
    {
        return await dbContext.TimePeriods
            .FirstOrDefaultAsync(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}