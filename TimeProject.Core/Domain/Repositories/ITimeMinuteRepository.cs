using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface ITimeMinuteRepository
{
    Task<TimeMinuteEntity> Create(TimeMinuteEntity entity);
    Task<List<TimeMinuteEntity>> CreateByList(List<TimeMinuteEntity> entities);
    Task<TimeMinuteEntity?> FindById(int id, int userId);
    Task<bool> Delete(TimeMinuteEntity entity);
}