using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimeMinuteRepository
{
    Task<MinuteRecord> Create(MinuteRecord entity);
    Task<List<MinuteRecord>> CreateByList(List<MinuteRecord> entities);
    Task<MinuteRecord?> FindById(int id, int userId);
    Task<bool> Delete(MinuteRecord entity);
}