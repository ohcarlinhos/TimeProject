using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Core.TimeRecord.Utils;
using API.Infra.Errors;
using Shared.General;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord.UseCases;

public class GetTimeRecordByCodeUseCase(ITimeRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetTimeRecordByCodeUseCase
{
    public async Task<Result<TimeRecordMap>> Handle(string code, int userId)
    {
        var result = new Result<TimeRecordMap>();
        var entity = await repo.Details(code, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(mapDataUtil.Handle(entity));
    }
}