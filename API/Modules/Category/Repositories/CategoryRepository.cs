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

    public List<CategoryEntity> Index(int userId, int page, int perPage)
    {
        return dbContext.Categories
            .Where(category => category.UserId == userId)
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<int> GetTotalItems(int userId)
    {
        return await dbContext.TimeRecords
            .Where(timeRecord => timeRecord.UserId == userId)
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