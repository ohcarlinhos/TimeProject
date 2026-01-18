using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class SessionRepository(CustomDbContext db) : ISessionRepository
{
    public ISession Create(ISession entity)
    {
        db.Sessions.Add((Session)entity);
        db.SaveChanges();
        return entity;
    }

    public ISession? FindById(int id, int userId)
    {
        return db.Sessions
            .Include(e => e.Periods)
            .FirstOrDefault(e => e.SessionId == id && e.UserId == userId);
    }

    public bool Delete(ISession entity)
    {
        db.Sessions.Remove((Session)entity);
        db.SaveChanges();
        return true;
    }
}