using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Infrastructure.Repositories;

public class RecordRepository(ProjectContext dbContext) : IRecordRepository
{
    public IIndexRepositoryResult<IRecord> Index(IPaginationQuery paginationQuery, int userId)
    {
        var query = dbContext.Records.AsQueryable();

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

        var count = query.Count();

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


        var entities = query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .ToList();

        return new IndexRepositoryResult<IRecord>
        {
            Count = count,
            Entities = entities
        };
    }

    public IList<SearchRecordItem> SearchTimeRecord(string search, int userId)
    {
        var query = dbContext.Records.AsQueryable();
        query = query.Where(tr => tr.UserId == userId);

        if (string.IsNullOrEmpty(search) == false)
            query = SearchWhereConditional(query, search);

        query = query.OrderBy(tr => tr.Meta == null).ThenByDescending(tr => tr.Meta!.LastTimeDate);

        return query
            .Select(e => new SearchRecordItem(e.Id, e.Code, e.Title))
            .Take(10)
            .ToList<SearchRecordItem>();
    }

    public IRecord Create(IRecord entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var record = (Record)entity;
        record.CreatedAt = now;
        record.UpdatedAt = now;

        dbContext.Records.Add(record);
        dbContext.SaveChanges();
        return entity;
    }

    public IRecord Update(IRecord entity)
    {
        var record = (Record)entity;
        record.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.Records.Update(record);
        dbContext.SaveChanges();
        return record;
    }

    public IRecord? Details(string code, int userId)
    {
        return dbContext.Records
            .Include(r => r.Category)
            .Include(r => r.Meta)
            .FirstOrDefault(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
    }

    public bool Delete(IRecord entity)
    {
        dbContext.Records.Remove((Record)entity);
        dbContext.SaveChanges();
        return true;
    }

    public IRecord? FindById(int id, int userId)
    {
        return dbContext.Records
            .FirstOrDefault(timeRecord => timeRecord.Id == id && timeRecord.UserId == userId);
    }

    public IList<IRecord> FindByIdList(IList<int> idList, int userId)
    {
        return dbContext.Records.Where(e => idList.Contains(e.Id))
            .Include(e => e.Category)
            .Include(e => e.Meta)
            .ToList<IRecord>();
    }

    public IRecord? FindByCode(string code, int userId)
    {
        return dbContext.Records
            .FirstOrDefault(timeRecord => timeRecord.Code == code && timeRecord.UserId == userId);
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