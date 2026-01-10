using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Repositories.Shared;

namespace TimeProject.Domain.Repositories;

public interface ITimeRecordRepository
{
    Task<IIndexRepositoryResult<TimeRecordEntity>> Index(PaginationQuery paginationQuery, int userId);
    Task<List<SearchTimeRecordItem>> SearchTimeRecord(string search, int userId);
    Task<TimeRecordEntity> Create(TimeRecordEntity entity);
    Task<TimeRecordEntity> Update(TimeRecordEntity entity);
    Task<bool> Delete(TimeRecordEntity entity);
    Task<TimeRecordEntity?> FindById(int id, int userId);
    Task<List<TimeRecordEntity>> FindByIdList(List<int> idList, int userId);
    Task<TimeRecordEntity?> FindByCode(string code, int userId);
    Task<TimeRecordEntity?> Details(string code, int userId);
}