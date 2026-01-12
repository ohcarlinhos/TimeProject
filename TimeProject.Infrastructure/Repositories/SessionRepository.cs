using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class SessionRepository(ProjectContext db) : ISessionRepository
{
    public ISession Create(ISession entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var recordSession = (Session)entity;
        recordSession.CreatedAt = now;
        recordSession.UpdatedAt = now;

        db.RecordSessions.Add(recordSession);
        db.SaveChanges();
        return recordSession;
    }

    public ISession? FindById(int id, int userId)
    {
        return db.RecordSessions
            .Include(e => e.PeriodRecords)
            .FirstOrDefault(e => e.Id == id && e.UserId == userId);
    }

    public bool Delete(ISession entity)
    {
        db.RecordSessions.Remove((Session)entity);
        db.SaveChanges();
        return true;
    }
}