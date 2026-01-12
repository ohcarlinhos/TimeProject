using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IMinuteRecordRepository
{
    IMinuteRecord Create(IMinuteRecord entity);
    IList<IMinuteRecord> CreateByList(IList<IMinuteRecord> entities);
    IMinuteRecord? FindById(int id, int userId);
    bool Delete(IMinuteRecord entity);
}