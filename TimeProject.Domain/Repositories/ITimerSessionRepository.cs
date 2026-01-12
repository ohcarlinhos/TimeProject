using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimerSessionRepository
{
    IRecordSession Create(IRecordSession entity);
    IRecordSession? FindById(int id, int userId);
    bool Delete(IRecordSession entity);
}