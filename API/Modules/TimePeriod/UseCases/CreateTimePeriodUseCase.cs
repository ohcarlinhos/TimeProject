using API.Core.TimePeriod;
using API.Core.TimePeriod.UseCases;
using API.Core.TimePeriod.Utils;
using API.Core.TimeRecord.UseCases;
using API.Infra.Errors;
using Entities;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public class CreateTimePeriodUseCase(
    ITimePeriodRepository repo,
    IGetTimeRecordByIdUseCase getTimeRecordByIdUseCase,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : ICreateTimePeriodUseCase
{
    public async Task<Result<TimePeriodEntity>> Handle(CreateTimePeriodDto dto, int userId)
    {
        var result = new Result<TimePeriodEntity>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);

        var findTrResult = await getTimeRecordByIdUseCase.Handle(dto.TimeRecordId, userId);
        if (findTrResult.HasError) return result.SetError(findTrResult.Message);

        var data = await repo
            .Create(new TimePeriodEntity
                {
                    UserId = userId,
                    TimeRecordId = dto.TimeRecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            );

        await syncTrMetaUseCase.Handle(data.TimeRecordId);

        return result.SetData(data);
    }
}