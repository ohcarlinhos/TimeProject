using TimeProject.Core.RemoveDependencies.General.Pagination;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories.Shared;

namespace TimeProject.Core.Domain.Repositories;

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