using API.Data;
using API.Modules.TimeRecord.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public List<TimeRecordEntity> Index(int userId, int page, int perPage, string search, string orderBy, string sort)
    {
        IQueryable<TimeRecordEntity> query = dbContext.TimeRecords;

        query = query.Where(tr => tr.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(tr => tr.Description != null && tr.Description.Contains(search));

        if (string.IsNullOrWhiteSpace(sort) || sort == "desc")
            query = query.OrderByDescending(tr => tr.TimePeriods.FirstOrDefault().Start);
        else
            query = query.OrderBy(tr => tr.TimePeriods.FirstOrDefault().Start);
        
        return query
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .Include(r => r.TimePeriods)
            .Include(r => r.Category)
            .ToList();
    }

    public async Task<int> GetTotalItems(int userId, string search)
    {
        IQueryable<TimeRecordEntity> query = dbContext.TimeRecords;

        query = query.Where(timeRecord => timeRecord.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(t => t.Description != null && t.Description.Contains(search));

        return await query.CountAsync();
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
            .Include(r => r.Category)
            .FirstOrDefaultAsync(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }
}