using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared.General;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public List<Entities.TimeRecord> Index(PaginationQuery paginationQuery, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();
        query = query.Where(tr => tr.UserId == userId);
        query = SearchWhereConditional(query, paginationQuery.Search);

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
            query = query.OrderByDescending(tr => tr.TimePeriods.FirstOrDefault()!.Start);
        else
            query = query.OrderBy(tr => tr.TimePeriods.FirstOrDefault()!.Start);

        return query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .Include(r => r.TimePeriods.OrderBy(tp => tp.Start))
            .Include(r => r.Category)
            .ToList();
    }

    public async Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();
        query = query.Where(timeRecord => timeRecord.UserId == userId);
        query = SearchWhereConditional(query, paginationQuery.Search);

        return await query.CountAsync();
    }

    public async Task<Entities.TimeRecord> Create(Entities.TimeRecord entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        await dbContext.TimeRecords.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Entities.TimeRecord> Update(Entities.TimeRecord entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.TimeRecords.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Entities.TimeRecord?> Details(string code, int userId)
    {
        return await dbContext.TimeRecords
            .Include(r => r.TimePeriods.OrderBy(tp => tp.Start))
            .Include(r => r.Category)
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }
    
    public async Task<bool> Delete(Entities.TimeRecord entity)
    {
        dbContext.TimeRecords.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Entities.TimeRecord?> FindById(int id, int userId)
    {
        return await dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }

    public async Task<Entities.TimeRecord?> FindByCode(string code, int userId)
    {
        return await dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }

    private static IQueryable<Entities.TimeRecord> SearchWhereConditional(IQueryable<Entities.TimeRecord> query,
        string? search)
    {
        if (string.IsNullOrWhiteSpace(search)) return query;

        return query.Where(tr =>
            tr.Code != null &&
            EF.Functions.Like(
                tr.Code.ToLower(),
                $"%{search.ToLower()}%") ||
            tr.Description != null &&
            EF.Functions.Like(
                tr.Title!.ToLower(),
                $"%{search.ToLower()}%")
        );
    }
}