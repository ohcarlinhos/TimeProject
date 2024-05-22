using API.Database;
using API.Modules.Shared;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodRepository(ProjectContext dbContext) : ITimePeriodRepository
{
    public List<Entities.TimePeriod> Index(int timeRecordId, int userId, int page, int perPage)
    {
        return dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int timeRecordId, int userId)
    {
        return await dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimeRecordId == timeRecordId && timePeriod.UserId == userId)
            .CountAsync();
    }

    public async Task<Entities.TimePeriod> Create(Entities.TimePeriod entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.TimePeriods.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<Entities.TimePeriod>> CreateByList(List<Entities.TimePeriod> entityList)
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

    public async Task<Entities.TimePeriod> Update(Entities.TimePeriod entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();
        
        dbContext.TimePeriods.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Entities.TimePeriod entity)
    {
        dbContext.TimePeriods.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByTimeRecordId(IEnumerable<Entities.TimePeriod> entityList)
    {
        dbContext.TimePeriods.RemoveRange(entityList);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Entities.TimePeriod?> FindById(int id, int userId)
    {
        return await dbContext.TimePeriods
            .FirstOrDefaultAsync(timePeriod => timePeriod.Id == id && timePeriod.UserId == userId);
    }
}