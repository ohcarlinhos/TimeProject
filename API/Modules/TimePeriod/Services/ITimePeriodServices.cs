using API.Modules.Shared;
using API.Modules.TimePeriod.Dto;
using API.Modules.TimePeriod.Map;

namespace API.Modules.TimePeriod.Services;

public interface ITimePeriodServices
{
    public Task<Result<Pagination<TimePeriodMap>>> Index(int timeRecordId, int userId, int page, int perPage);

    Task<Result<Entities.TimePeriod>> Create(
        CreateTimePeriodDto dto,
        int userId
    );

    Task<Result<List<Entities.TimePeriod>>> CreateByList(
        List<TimePeriodDto> model,
        int timeRecord,
        int userId
    );

    Task<Result<Entities.TimePeriod>> Update(int id, TimePeriodDto dto, int userId);

    Task<Result<bool>> Delete(int id, int userId);
}