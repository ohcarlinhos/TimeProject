using API.Modules.Shared;
using API.Modules.TimeRecord.Dto;
using API.Modules.TimeRecord.Map;

namespace API.Modules.TimeRecord.Services;

public interface ITimeRecordServices
{
    Task<Result<Pagination<TimeRecordMap>>> Index(int userId, int page, int perPage, string search, string orderBy, string sort);
    Task<Result<TimeRecordMap>> Create(CreateTimeRecordDto dto, int userId);
    Task<Result<TimeRecordMap>> Update(int id, UpdateTimeRecordDto dto, int userId);
    Task<Result<TimeRecordMap>> Details(string code, int userId);
    Task<Result<bool>> Delete(int id, int userId); 
}