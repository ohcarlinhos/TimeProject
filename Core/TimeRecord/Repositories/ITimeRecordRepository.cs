using Entities;
using Shared.General.Pagination;
using Shared.General.Repositories;

namespace Core.TimeRecord.Repositories;

public interface ITimeRecordRepository
{
    Task<IndexRepositoryResult<TimeRecordEntity>> Index(PaginationQuery paginationQuery, int userId);
    Task<List<SearchTimeRecordItem>> SearchTimeRecord(string search, int userId);
    Task<TimeRecordEntity> Create(TimeRecordEntity entity);
    Task<TimeRecordEntity> Update(TimeRecordEntity entity);
    Task<bool> Delete(TimeRecordEntity entity);
    Task<TimeRecordEntity?> FindById(int id, int userId);
    Task<TimeRecordEntity?> FindByCode(string code, int userId);
    Task<TimeRecordEntity?> Details(string code, int userId);
}