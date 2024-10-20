using API.Core.TimePeriod;
using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Pagination;

namespace API.Modules.TimePeriod;

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

    public async Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entityList)
    {
        var now = DateTime.Now.ToUniversalTime();

        foreach (var entity in entityList)
        {
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
        }

        dbContext.TimePeriods.AddRange(entityList);
        await dbContext.SaveChangesAsync();
        return entityList;
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