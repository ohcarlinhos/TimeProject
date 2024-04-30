using API.Modules.TimeRecord.Entities;

namespace API.Modules.TimeRecord.Repositories;

public interface ITimeRecordRepository
{
    List<TimeRecordEntity> Index(int userId, int page, int perPage);
    Task<TimeRecordEntity> Create(TimeRecordEntity entity);
    Task<TimeRecordEntity> Update(TimeRecordEntity entity);
    Task<bool> Delete(TimeRecordEntity entity);
    Task<TimeRecordEntity?> FindById(int id, int userId);
    Task<TimeRecordEntity?> Details(int id, int userId);
}