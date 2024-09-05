using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public interface ITimePeriodRepository
{
    List<TimePeriodEntity> Index(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<IEnumerable<DatedTime>> Dated(int timeRecordId, int userId);
    Task<TimePeriodEntity> Create(TimePeriodEntity entity);
    Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entityList);
    Task<TimePeriodEntity> Update(TimePeriodEntity entity);
    Task<bool> Delete(TimePeriodEntity entity);
    Task<bool> DeleteAllByTimeRecordId(IEnumerable<TimePeriodEntity> entityList);
    Task<TimePeriodEntity?> FindById(int id, int userId);
}