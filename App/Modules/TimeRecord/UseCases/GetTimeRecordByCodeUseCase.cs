using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Core.TimeRecord.Utils;
using App.Infra.Errors;
using Shared.General;
using Shared.TimeRecord;

namespace App.Modules.TimeRecord.UseCases;

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