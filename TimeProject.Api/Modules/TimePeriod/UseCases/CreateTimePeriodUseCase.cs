using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimePeriod;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.TimePeriod.UseCases;

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
            return result.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);

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