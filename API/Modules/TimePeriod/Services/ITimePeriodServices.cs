using API.Modules.Shared;
using API.Modules.TimePeriod.DTO;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimePeriod.Models;

namespace API.Modules.TimePeriod.Services;

public interface ITimePeriodServices
{
    public Result<List<TimePeriodDto>> Index(int timeRecordId, int userId, int page, int perPage);

    Task<Result<TimePeriodEntity>> Create(
        CreateTimePeriodModel model,
        int userId
    );

    Task<Result<List<TimePeriodEntity>>> CreateByList(
        List<TimePeriodModel> model,
        int timeRecord,
        int userId
    );

    Task<Result<TimePeriodEntity>> Update(int id, TimePeriodModel model, int userId);

    Task<Result<bool>> Delete(int id, int userId);
}