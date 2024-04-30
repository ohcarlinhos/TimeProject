using API.Modules.Shared;
using API.Modules.TimeRecord.DTO;
using API.Modules.TimeRecord.Models;

namespace API.Modules.TimeRecord.Services;

public interface ITimeRecordServices
{
    Result<List<TimeRecordDto>> Index(int userId, int page, int perPage);
    Task<Result<TimeRecordDto>> Create(CreateTimeRecordModel model, int userId);
    Task<Result<TimeRecordDto>> Update(int id, UpdateTimeRecordModel model, int userId);
    Task<Result<TimeRecordDto>> Details(int id, int userId);
    Task<Result<bool>> Delete(int id, int userId); 
}