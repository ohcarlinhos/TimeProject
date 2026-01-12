using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserRepository(ProjectContext dbContext) : IUserRepository
{
    public IList<IUser> Index(IPaginationQuery paginationQuery)
    {
        IQueryable<User> query = dbContext.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
            query = query.OrderByDescending(user => user.CreatedAt);
        else
            query = query.OrderBy(user => user.CreatedAt);

        return query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList<IUser>();
    }

    public int GetTotalItems(IPaginationQuery paginationQuery)
    {
        IQueryable<User> query = dbContext.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.Count();
    }

    public IUser Create(IUser entity)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        var user = (User)entity;
        user.CreatedAt = now;
        user.UpdatedAt = now;

        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        return user;
    }

    public IUser Update(IUser entity)
    {
        var user = (User)entity;
        user.UpdatedAt = DateTime.Now.ToUniversalTime();

        dbContext.Users.Update(user);
        dbContext.SaveChanges();
        return entity;
    }

    public bool Delete(int id)
    {
        var entity = FindById(id);
        if (entity == null) return true;

        dbContext.Users.Remove((User)entity);
        dbContext.SaveChanges();
        return true;
    }

    public IUser? FindById(int id)
    {
        return dbContext.Users.FirstOrDefault(i => i.Id == id);
    }

    public IUser? FindByEmail(string email)
    {
        return dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool EmailIsAvailable(string email)
    {
        return FindByEmail(email) == null;
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