using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class UserRepository(CustomDbContext db) : IUserRepository
{
    public IList<IUser> Index(IPaginationQuery paginationQuery)
    {
        IQueryable<User> query = db.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
            query = query.OrderByDescending(user => user.UserId);
        else
            query = query.OrderBy(user => user.UserId);

        return query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList<IUser>();
    }

    public int GetTotalItems(IPaginationQuery paginationQuery)
    {
        IQueryable<User> query = db.Users;

        if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
            query = SearchWhereConditional(query, paginationQuery.Search);

        return query.Count();
    }

    public IUser Create(IUser entity)
    {
        var user = (User)entity;
        db.Users.Add(user);
        return user;
    }

    public IUser Update(IUser entity)
    {
        db.Users.Update((User)entity);
        return entity;
    }

    public bool Delete(int id)
    {
        var entity = FindById(id);
        if (entity == null) return true;
        db.Users.Remove((User)entity);
        return true;
    }

    public IUser? FindById(int id)
    {
        return db.Users.FirstOrDefault(i => i.UserId == id);
    }

    public IUser? FindByEmail(string email)
    {
        return db.Users.FirstOrDefault(u => u.Email == email);
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