using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserRepository(ProjectContext dbContext) : IUserRepository
{
    public List<User> Index(PaginationQuery paginationQuery)
    {
        IQueryable<User> query = dbContext.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
            query = query.OrderByDescending(tr => tr.CreatedAt);
        else
            query = query.OrderBy(tr => tr.CreatedAt);

        return query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();
    }

    public int GetTotalItems(PaginationQuery paginationQuery)
    {
        IQueryable<User> query = dbContext.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.Count();
    }

    public async Task<User> Create(User entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.Users.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<User> Update(User entity)
    {
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.Users.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await FindById(id);
        if (entity == null) return true;

        dbContext.Users.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> FindById(int id)
    {
        return await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<User?> FindByEmail(string email)
    {
        return await dbContext.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> EmailIsAvailable(string email)
    {
        return await FindByEmail(email) == null;
    }

    private static IQueryable<User> SearchWhereConditional(IQueryable<User> query, string search)
    {
        return query.Where(u =>
            EF.Functions.Like(
                u.Name.ToLower(),
                $"%{search.ToLower()}%"
            )
        );
    }
}