using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace API.Modules.Category.Repositories;

public partial class CategoryRepository(ProjectContext dbContext) : ICategoryRepository
{
    public List<Entities.Category> Index(int userId)
    {
        return dbContext.Categories
            .Where(category => category.UserId == userId)
            .ToList();
    }

    public List<Entities.Category> Index(PaginationQuery paginationQuery, int userId)
    {
        IQueryable<Entities.Category> query = dbContext.Categories;
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
        IQueryable<Entities.Category> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.CountAsync();
    }

    public async Task<Entities.Category> Create(Entities.Category entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;
        
        dbContext.Categories.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Entities.Category> Update(Entities.Category entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.Categories.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Entities.Category entity)
    {
        dbContext.Categories.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Entities.Category?> FindById(int id)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Entities.Category?> FindById(int id, int userId)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task<Entities.Category?> FindByName(string name, int userId)
    {
        return await dbContext.Categories
            .Where(category => category.Name == name && category.UserId == userId)
            .FirstOrDefaultAsync();
    }
    
    private static IQueryable<Entities.Category> SearchWhereConditional(IQueryable<Entities.Category> query, string search)
    {
        return query.Where(c =>
            EF.Functions.Like(
                c.Name.ToLower(),
                $"%{search.ToLower()}%")
        );
    } 
}