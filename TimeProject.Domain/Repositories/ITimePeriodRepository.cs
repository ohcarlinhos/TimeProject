using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface ITimePeriodRepository
{
    List<PeriodRecord> Index(int timeRecordId, int userId, PaginationQuery paginationQuery);
    Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<PeriodRecord> Create(PeriodRecord entity);
    Task<List<PeriodRecord>> CreateByList(List<PeriodRecord> entities);
    Task<bool> DeleteByList(List<PeriodRecord> entityList);
    Task<PeriodRecord> Update(PeriodRecord entity);
    Task<bool> Delete(PeriodRecord entity);
    Task<PeriodRecord?> FindById(int id, int userId);
}