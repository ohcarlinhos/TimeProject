using API.Data;
using API.Modules.TimeRecord.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public List<TimeRecordEntity> Index(int userId, int page, int perPage)
    {
        return dbContext.TimeRecords
            .Where(timeRecord => timeRecord.UserId == userId)
            .Include(r => r.TimePeriods)
            .Include(r => r.Category)
            .Skip(page > 0 ? page - 1 : page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<TimeRecordEntity> Create(TimeRecordEntity entity)
    {
        await dbContext.TimeRecords.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TimeRecordEntity> Update(TimeRecordEntity entity)
    {
        dbContext.TimeRecords.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(TimeRecordEntity entity)
    {
        dbContext.TimeRecords.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TimeRecordEntity?> FindById(int id, int userId)
    {
        return await dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }

    public async Task<TimeRecordEntity?> Details(int id, int userId)
    {
        return await dbContext.TimeRecords
            .Include(r => r.TimePeriods)
            .FirstOrDefaultAsync(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }
}