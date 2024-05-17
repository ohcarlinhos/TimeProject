using API.Data;
using API.Modules.Category.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Category.Repositories;

public partial class CategoryRepository(ProjectContext dbContext) : ICategoryRepository
{
    public List<CategoryEntity> Index(int userId)
    {
        return dbContext.Categories
            .Where(category => category.UserId == userId)
            .ToList();
    }

    public List<CategoryEntity> Index(int userId, int page, int perPage, string search, string sort)
    {
        IQueryable<CategoryEntity> query = dbContext.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(c => c.Name.Contains(search));

        if (string.IsNullOrWhiteSpace(sort) || sort == "asc")
            query = query.OrderBy(c => c.Name);
        else
            query = query.OrderByDescending(c => c.Name);

        return query
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int userId, string search)
    {
        return await dbContext.Categories
            .Where(c => c.UserId == userId)
            .CountAsync();
    }

    public async Task<CategoryEntity> Create(CategoryEntity entity)
    {
        dbContext.Categories.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<CategoryEntity> Update(CategoryEntity entity)
    {
        dbContext.Categories.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(CategoryEntity entity)
    {
        dbContext.Categories.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<CategoryEntity?> FindById(int id)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CategoryEntity?> FindById(int id, int userId)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task<CategoryEntity?> FindByName(string name, int userId)
    {
        return await dbContext.Categories
            .Where(category => category.Name == name && category.UserId == userId)
            .FirstOrDefaultAsync();
    }
}