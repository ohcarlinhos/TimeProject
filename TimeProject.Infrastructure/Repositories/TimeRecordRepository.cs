using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Infrastructure.Repositories;

public class TimeRecordRepository(ProjectContext dbContext) : ITimeRecordRepository
{
    public async Task<IIndexRepositoryResult<Record>> Index(PaginationQuery paginationQuery, int userId)
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

        query = paginationQuery.SortProp switch
        {
            "title" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Title)
                : query.OrderByDescending(tr => tr.Title),

            "code" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Code)
                : query.OrderByDescending(tr => tr.Code),

            "timeOnSeconds" => paginationQuery.Sort == "asc"
                ? query.OrderBy(tr => tr.Meta == null).ThenBy(p => p.Meta!.TimeOnSeconds)
                : query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.TimeOnSeconds),

            _ => paginationQuery.Sort == "asc" // Padrão: Último Progresso
                ? query.OrderBy(tr => tr.Meta == null).ThenBy(p => p.Meta!.LastTimeDate)
                : query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.LastTimeDate)
        };


        var entities = await query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .ToListAsync();

        return new IndexRepositoryResult<Record>
        {
            Count = count,
            Entities = entities
        };
    }

    public Task<List<SearchTimeRecordItem>> SearchTimeRecord(string search, int userId)
    {
        var query = dbContext.TimeRecords.AsQueryable();
        query = query.Where(tr => tr.UserId == userId);

        if (string.IsNullOrEmpty(search) == false)
            query = SearchWhereConditional(query, search);

        query = query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.LastTimeDate);

        return query
            .Select(e => new SearchTimeRecordItem(e.Id, e.Code, e.Title))
            .Take(10)
            .ToListAsync();
    }

    public async Task<Record> Create(Record entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        await dbContext.TimeRecords.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Record> Update(Record entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.TimeRecords.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Record?> Details(string code, int userId)
    {
        return await dbContext.TimeRecords
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }

    public async Task<bool> Delete(Record entity)
    {
        dbContext.TimeRecords.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public Task<Record?> FindById(int id, int userId)
    {
        return dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }

    public Task<List<Record>> FindByIdList(List<int> idList, int userId)
    {
        return dbContext.TimeRecords.Where(e => idList.Contains(e.Id))
            .Include(e => e.Category)
            .Include(e => e.Meta)
            .ToListAsync();
    }

    public async Task<Record?> FindByCode(string code, int userId)
    {
        return await dbContext.TimeRecords
            .FirstOrDefaultAsync(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }

    private static IQueryable<Record> SearchWhereConditional(IQueryable<Record> query,
        string? search)
    {
        if (string.IsNullOrWhiteSpace(search)) return query;

        return query.Where(tr =>
            EF.Functions.Like(
                tr.Code.ToLower(),
                $"%{search.ToLower()}%") ||
            (tr.Title != null &&
             EF.Functions.Like(
                 tr.Title!.ToLower(),
                 $"%{search.ToLower()}%"))
        );
    }
}