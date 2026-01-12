using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IMinuteRepository
{
    IMinute Create(IMinute entity);
    IList<IMinute> CreateByList(IList<IMinute> entities);
    IMinute? FindById(int id, int userId);
    bool Delete(IMinute entity);
}