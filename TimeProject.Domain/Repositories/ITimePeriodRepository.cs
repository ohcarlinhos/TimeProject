using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

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