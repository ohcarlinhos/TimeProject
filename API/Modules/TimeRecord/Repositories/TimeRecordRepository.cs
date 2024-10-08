using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General;
using Shared.General.Repositories;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public async Task<IndexRepositoryResult<TimeRecordEntity>> Index(PaginationQuery paginationQuery, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();
        query = query.Where(tr => tr.UserId == userId);
        query = SearchWhereConditional(query, paginationQuery.Search);

        if (paginationQuery.Filters != null)
            foreach (var filter in paginationQuery.Filters)
            {
                var split = filter.Split("::");

                if (split[0] == "category")
                {
                    var id = int.Parse(split[^1]);
                    query = query.Where(tr => tr.CategoryId == id);
                }
            }

        var count = await query.CountAsync();

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
            query = query.OrderBy(tr => tr.Meta != null ? 0 : 1)
                .ThenByDescending(tr => tr.Meta!.LastTimePeriodDate);
        else
            query = query.OrderBy(tr => tr.Meta != null ? 0 : 1)
                .ThenBy(p => p.Meta!.LastTimePeriodDate);

        var entities = await query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .ToListAsync();

        return new IndexRepositoryResult<TimeRecordEntity>()
        {
            Count = count,
            Entities = entities
        };
    }

    public async Task<TimeRecordEntity> Create(TimeRecordEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        await dbContext.TimeRecords.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TimeRecordEntity> Update(TimeRecordEntity entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.TimeRecords.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TimeRecordEntity?> Details(string code, int userId)
    {
        return await dbContext.TimeRecords
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
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

    public async Task<TimeRecordEntity?> FindByCode(string code, int userId)
    {
        return await dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }

    private static IQueryable<TimeRecordEntity> SearchWhereConditional(IQueryable<TimeRecordEntity> query,
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