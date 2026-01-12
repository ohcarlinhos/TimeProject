using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface IPeriodRecordRepository
{
    IList<IPeriodRecord> Index(int timeRecordId, int userId, IPaginationQuery paginationQuery);
    int GetTotalItems(int timeRecordId, IPaginationQuery paginationQuery, int userId);
    IPeriodRecord Create(IPeriodRecord entity);
    IList<IPeriodRecord> CreateByList(IList<IPeriodRecord> entities);
    bool DeleteByList(IList<IPeriodRecord> entityList);
    IPeriodRecord Update(IPeriodRecord entity);
    bool Delete(IPeriodRecord entity);
    IPeriodRecord? FindById(int id, int userId);
}