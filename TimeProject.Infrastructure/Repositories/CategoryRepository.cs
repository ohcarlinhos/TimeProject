using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class CategoryRepository(ProjectContext dbContext) : ICategoryRepository
{
    public List<Category> Index(int userId, bool onlyWithData)
    {
        return onlyWithData
            ? dbContext.TimeRecords
                .Where(e => e.Category != null && e.UserId == userId)
                .Select(e => e.Category)
                .Distinct()
                .ToList()!
            : dbContext.Categories
                .Where(category => category.UserId == userId)
                .ToList();
    }

    public List<Category> Index(PaginationQuery paginationQuery, int userId)
    {
        IQueryable<Category> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "asc")
            query = query.OrderBy(c => c.Name);
        else
            query = query.OrderByDescending(c => c.Name);

        return query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();
    }

    public Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId)
    {
        IQueryable<Category> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.CountAsync();
    }

    public async Task<Category> Create(Category entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.Categories.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Category> Update(Category entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.Categories.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Category entity)
    {
        dbContext.Categories.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Category?> FindById(int id)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> FindById(int id, int userId)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task<Category?> FindByName(string name, int userId)
    {
        return await dbContext.Categories
            .Where(category => category.Name == name && category.UserId == userId)
            .FirstOrDefaultAsync();
    }

    private static IQueryable<Category> SearchWhereConditional(IQueryable<Category> query, string search)
    {
        return query.Where(c =>
            EF.Functions.Like(
                c.Name.ToLower(),
                $"%{search.ToLower()}%")
        );
    }
}