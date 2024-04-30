using API.Data;
using API.Modules.TimePeriod.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodRepository(ProjectContext dbContext) : ITimePeriodRepository
{
    public List<TimePeriodEntity> Index(int timeRecordId, int userId, int page, int perPage)
    {
        return dbContext.TimePeriods
            .Where(timePeriod => timePeriod.TimerRecordId == timeRecordId && timePeriod.UserId == userId)
            .ToList();
    }

    public async Task<TimePeriodEntity> Create(TimePeriodEntity entity)
    {
        dbContext.TimePeriods.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entityList)
    {
        dbContext.TimePeriods.AddRange(entityList);
        await dbContext.SaveChangesAsync();
        return entityList;
    }

    public async Task<TimePeriodEntity> Update(TimePeriodEntity entity)
    {
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

    public async Task<bool> DeleteAllByRegistroId(IEnumerable<TimePeriodEntity> entityList)
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