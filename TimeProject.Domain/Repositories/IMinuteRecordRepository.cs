using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IMinuteRecordRepository
{
    IMinute Create(IMinute entity);
    IList<IMinute> CreateByList(IList<IMinute> entities);
    IMinute? FindById(int id, int userId);
    bool Delete(IMinute entity);
}