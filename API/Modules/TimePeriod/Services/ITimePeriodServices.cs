using API.Modules.Shared;
using API.Modules.TimePeriod.DTO;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimePeriod.Models;

namespace API.Modules.TimePeriod.Services;

public interface ITimePeriodServices
{
    public Task<Result<Pagination<TimePeriodDto>>> Index(int timeRecordId, int userId, int page, int perPage);

    Task<Result<Entities.TimePeriod>> Create(
        CreateTimePeriodModel model,
        int userId
    );

    Task<Result<List<Entities.TimePeriod>>> CreateByList(
        List<TimePeriodModel> model,
        int timeRecord,
        int userId
    );

    Task<Result<Entities.TimePeriod>> Update(int id, TimePeriodModel model, int userId);

    Task<Result<bool>> Delete(int id, int userId);
}