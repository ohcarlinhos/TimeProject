using Shared.General;

namespace API.Modules.TimeRecord.Repositories;

public interface ITimeRecordRepository
{
    List<Entities.TimeRecord> Index(PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(PaginationQuery paginationQuery, int userId);
    Task<Entities.TimeRecord> Create(Entities.TimeRecord entity);
    Task<Entities.TimeRecord> Update(Entities.TimeRecord entity);
    Task<bool> Delete(Entities.TimeRecord entity);
    Task<Entities.TimeRecord?> FindById(int id, int userId);
    Task<Entities.TimeRecord?> FindByCode(string code, int userId);
    Task<Entities.TimeRecord?> Details(string code, int userId);
}