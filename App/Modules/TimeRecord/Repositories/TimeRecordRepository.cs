using Core.TimeRecord;
using Core.TimeRecord.Repositories;
using App.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.General.Pagination;
using Shared.General.Repositories;

namespace App.Modules.TimeRecord.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public async Task<IndexRepositoryResult<TimeRecordEntity>> Index(PaginationQuery paginationQuery, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();

        query = query.Where(tr => tr.UserId == userId);
        query = SearchWhereConditional(query, paginationQuery.Search);

        if (paginationQuery.Filters != null)
        {
            foreach (var filter in paginationQuery.Filters)
            {
                var split = filter.Split("::");

                if (split[0] == "category")
                {
                    var id = int.Parse(split[^1]);
                    query = query.Where(tr => tr.CategoryId == id);
                }
            }
        }

        var count = await query.CountAsync();

        query = paginationQuery.SortProp switch
        {
            "title" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Title)
                : query.OrderByDescending(tr => tr.Title),

            "code" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Title)
                : query.OrderByDescending(tr => tr.Title),

            "timeOnSeconds" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Meta == null).ThenBy(p => p.Meta!.TimeOnSeconds)
                : query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.TimeOnSeconds),

            _ => paginationQuery.Sort == "asc" // Padrão: Último Progresso
                ? query.OrderBy(tr => tr.Meta == null).ThenBy(p => p.Meta!.LastTimePeriodDate)
                : query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.LastTimePeriodDate)
        };


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

    public Task<List<SearchTimeRecordItem>> SearchTimeRecord(string search, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();
        query = query.Where(tr => tr.UserId == userId);

        if (search.IsNullOrEmpty() == false)
            query = SearchWhereConditional(query, search);

        query = query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.LastTimePeriodDate);

        return query
            .Select(e => new SearchTimeRecordItem(e.Id, e.Code, e.Title))
            .Take(10)
            .ToListAsync();
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
            EF.Functions.Like(
                tr.Code.ToLower(),
                $"%{search.ToLower()}%") ||
            tr.Title != null &&
            EF.Functions.Like(
                tr.Title!.ToLower(),
                $"%{search.ToLower()}%")
        );
    }
}