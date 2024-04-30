using API.Modules.TimePeriod.Entities;

namespace API.Modules.TimePeriod.Repositories;

public interface ITimePeriodRepository
{
    List<TimePeriodEntity> Index(int timeRecordId, int userId, int page, int perPage);
    Task<TimePeriodEntity> Create(TimePeriodEntity entity);
    Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entityList);
    Task<TimePeriodEntity> Update(TimePeriodEntity entity);
    Task<bool> Delete(TimePeriodEntity entity);
    Task<bool> DeleteAllByRegistroId(IEnumerable<TimePeriodEntity> entityList);
    Task<TimePeriodEntity?> FindById(int id, int userId);
}