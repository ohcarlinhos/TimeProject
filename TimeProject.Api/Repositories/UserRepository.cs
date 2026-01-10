using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;

namespace TimeProject.Api.Repositories;

public class UserRepository(ProjectContext dbContext) : IUserRepository
{
    public List<UserEntity> Index(PaginationQuery paginationQuery)
    {
        IQueryable<UserEntity> query = dbContext.Users;

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
        IQueryable<UserEntity> query = dbContext.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.Count();
    }

    public async Task<UserEntity> Create(UserEntity entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        dbContext.Users.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<UserEntity> Update(UserEntity entity)
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

    public async Task<UserEntity?> FindById(int id)
    {
        return await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<UserEntity?> FindByEmail(string email)
    {
        return await dbContext.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> EmailIsAvailable(string email)
    {
        return await FindByEmail(email) == null;
    }

    private static IQueryable<UserEntity> SearchWhereConditional(IQueryable<UserEntity> query, string search)
    {
        return query.Where(u =>
            EF.Functions.Like(
                u.Name.ToLower(),
                $"%{search.ToLower()}%"
            )
        );
    }
}