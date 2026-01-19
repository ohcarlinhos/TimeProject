using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;

namespace TimeProject.Domain.Repositories;

public interface IRecordRepository
{
    IIndexRepositoryResult<IRecord> Index(IPaginationQuery paginationQuery, int userId);
    IList<SearchRecordItem> SearchRecord(string search, int userId);
    IRecord Create(IRecord entity);
    IRecord Update(IRecord entity);
    bool Delete(IRecord entity);
    IRecord? FindById(int id, int userId);
    IEnumerable<IRecord> FindByIdList(IEnumerable<int> idList, int userId);
    IRecord? FindByCode(string code, int userId);
    IRecord? Details(string code, int userId);
}