using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.Repositories;

public interface ITimeRecordRepository
{
    Task<IIndexRepositoryResult<Entities.Record>> Index(PaginationQuery paginationQuery, int userId);
    Task<List<SearchTimeRecordItem>> SearchTimeRecord(string search, int userId);
    Task<Entities.Record> Create(Entities.Record entity);
    Task<Entities.Record> Update(Entities.Record entity);
    Task<bool> Delete(Entities.Record entity);
    Task<Entities.Record?> FindById(int id, int userId);
    Task<List<Entities.Record>> FindByIdList(List<int> idList, int userId);
    Task<Entities.Record?> FindByCode(string code, int userId);
    Task<Entities.Record?> Details(string code, int userId);
}