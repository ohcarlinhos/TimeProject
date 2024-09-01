using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public class DatedResult
{
    public List<DatedTimePeriod> DatedTimePeriods { get; set; } = null!;
    public int TotalItems { get; set; }
}

public interface ITimePeriodRepository
{
    List<Entities.TimePeriod> Index(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<DatedResult> Dated(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<int> GetTotalItems(int timeRecordId, PaginationQuery paginationQuery, int userId);
    Task<Entities.TimePeriod> Create(Entities.TimePeriod entity);
    Task<List<Entities.TimePeriod>> CreateByList(List<Entities.TimePeriod> entityList);
    Task<Entities.TimePeriod> Update(Entities.TimePeriod entity);
    Task<bool> Delete(Entities.TimePeriod entity);
    Task<bool> DeleteAllByTimeRecordId(IEnumerable<Entities.TimePeriod> entityList);
    Task<Entities.TimePeriod?> FindById(int id, int userId);
}