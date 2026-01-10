using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.Repositories;

public interface ITimePeriodRepository
{
    List<TimePeriodEntity> Index(int timeRecordId, int userId, PaginationQuery paginationQuery);
    Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<TimePeriodEntity> Create(TimePeriodEntity entity);
    Task<List<TimePeriodEntity>> CreateByList(List<TimePeriodEntity> entities);
    Task<bool> DeleteByList(List<TimePeriodEntity> entityList);
    Task<TimePeriodEntity> Update(TimePeriodEntity entity);
    Task<bool> Delete(TimePeriodEntity entity);
    Task<TimePeriodEntity?> FindById(int id, int userId);
}