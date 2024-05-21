using API.Data;
using API.Modules.Category.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Category.Repositories;

public partial class CategoryRepository(ProjectContext dbContext) : ICategoryRepository
{
    public List<Entities.Category> Index(int userId)
    {
        return dbContext.Categories
            .Where(category => category.UserId == userId)
            .ToList();
    }

    public List<Entities.Category> Index(int userId, int page, int perPage, string search, string sort)
    {
        IQueryable<Entities.Category> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(c =>
                EF.Functions.Like(
                    c.Name.ToLower(),
                    $"%{search.ToLower()}%")
            );

        if (string.IsNullOrWhiteSpace(sort) || sort == "asc")
            query = query.OrderBy(c => c.Name);
        else
            query = query.OrderByDescending(c => c.Name);

        return query
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
    }

    public Task<int> GetTotalItems(int userId, string search)
    {
        IQueryable<Entities.Category> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(c =>
                EF.Functions.Like(
                    c.Name.ToLower(),
                    $"%{search.ToLower()}%")
            );

        return query.CountAsync();
    }

    public async Task<Entities.Category> Create(Entities.Category entity)
    {
        dbContext.Categories.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Entities.Category> Update(Entities.Category entity)
    {
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
}