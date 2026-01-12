using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface IPeriodRecordRepository
{
    IList<IPeriod> Index(int timeRecordId, int userId, IPaginationQuery paginationQuery);
    int GetTotalItems(int timeRecordId, IPaginationQuery paginationQuery, int userId);
    IPeriod Create(IPeriod entity);
    IList<IPeriod> CreateByList(IList<IPeriod> entities);
    bool DeleteByList(IList<IPeriod> entityList);
    IPeriod Update(IPeriod entity);
    bool Delete(IPeriod entity);
    IPeriod? FindById(int id, int userId);
}