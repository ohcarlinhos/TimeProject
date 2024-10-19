using API.Core.TimePeriod;
using API.Core.TimePeriod.UseCases;
using API.Core.TimePeriod.Utils;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public class UpdateTimePeriodUseCase(
    ITimePeriodRepository repo,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : IUpdateTimePeriodUseCase
{
    public async Task<Result<TimePeriodEntity>> Handle(int id, TimePeriodDto dto, int userId)
    {
        var result = new Result<TimePeriodEntity>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = await repo.FindById(id, userId);
        if (timePeriod == null) return result.SetError(TimePeriodErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = await repo.Update(timePeriod);
        await syncTrMetaUseCase.Handle(data.TimeRecordId);

        return result.SetData(data);
    }
}