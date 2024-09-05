using Entities;
using Shared.General;

namespace API.Modules.TimeRecord.Repositories;

public interface ITimeRecordRepository
{
    List<TimeRecordEntity> Index(PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId);
    Task<TimeRecordEntity> Create(TimeRecordEntity entity);
    Task<TimeRecordEntity> Update(TimeRecordEntity entity);
    Task<bool> Delete(TimeRecordEntity entity);
    Task<TimeRecordEntity?> FindById(int id, int userId);
    Task<TimeRecordEntity?> FindByCode(string code, int userId);
    Task<TimeRecordEntity?> Details(string code, int userId);
}