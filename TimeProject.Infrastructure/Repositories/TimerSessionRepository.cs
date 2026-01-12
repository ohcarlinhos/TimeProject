using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Infrastructure.Repositories;

public class TimerSessionRepository(ProjectContext db) : ITimerSessionRepository
{
    public IRecordSession Create(IRecordSession entity)
    {
        var now = DateTime.Now.ToUniversalTime();

        var recordSession = (RecordSession)entity;
        recordSession.CreatedAt = now;
        recordSession.UpdatedAt = now;

        db.RecordSessions.Add(recordSession);
        db.SaveChanges();
        return recordSession;
    }

    public IRecordSession? FindById(int id, int userId)
    {
        return db.RecordSessions
            .Include(e => e.PeriodRecords)
            .FirstOrDefault(e => e.Id == id && e.UserId == userId);
    }

    public bool Delete(IRecordSession entity)
    {
        db.RecordSessions.Remove((RecordSession)entity);
        db.SaveChanges();
        return true;
    }
}