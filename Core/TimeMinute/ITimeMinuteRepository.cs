using Entities;

namespace Core.TimeMinute;

public interface ITimeMinuteRepository
{
    Task<TimeMinuteEntity> Create(TimeMinuteEntity entity);
    Task<List<TimeMinuteEntity>> CreateByList(List<TimeMinuteEntity> entities);
    Task<TimeMinuteEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimeMinuteEntity entity);
}