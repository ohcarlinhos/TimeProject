using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class CategoryRepository(CustomDbContext db) : ICategoryRepository
{
    public IList<ICategory> Index(int userId, bool onlyWithData)
    {
        return onlyWithData
            ? db.Records
                .Where(e => e.Category != null && e.UserId == userId)
                .Select(e => e.Category)
                .Distinct()!
                .ToList<ICategory>()
            : db.Categories
                .Where(category => category.UserId == userId)
                .ToList<ICategory>();
    }

    public IList<ICategory> Index(IPaginationQuery paginationQuery, int userId)
    {
        IQueryable<ICategory> query = db.Categories;
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

    public int GetTotalItems(IPaginationQuery paginationQuery, int userId)
    {
        IQueryable<ICategory> query = db.Categories;
        query = query.Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.Count();
    }

    public ICategory Create(ICategory entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        var category = (Category)entity;

        category.CreatedAt = now;
        category.UpdatedAt = now;

        db.Categories.Add(category);
        db.SaveChanges();
        return category;
    }

    public ICategory Update(ICategory entity)
    {
        var category = (Category)entity;
        category.UpdatedAt = DateTime.Now.ToUniversalTime();

        db.Categories.Update(category);
        db.SaveChanges();
        return category;
    }

    public bool Delete(ICategory entity)
    {
        db.Categories.Remove((Category)entity);
        db.SaveChanges();
        return true;
    }

    public ICategory? FindById(int id)
    {
        return db.Categories.FirstOrDefault(c => c.CategoryId == id);
    }

    public ICategory? FindById(int id, int userId)
    {
        return db.Categories.FirstOrDefault(c => c.CategoryId == id && c.UserId == userId);
    }

    public ICategory? FindByName(string name, int userId)
    {
        return db.Categories.FirstOrDefault(category => category.Name == name && category.UserId == userId);
    }

    private static IQueryable<ICategory> SearchWhereConditional(IQueryable<ICategory> query, string search)
    {
        return query.Where(c =>
            EF.Functions.Like(
                c.Name.ToLower(),
                $"%{search.ToLower()}%")
        );
    }
}