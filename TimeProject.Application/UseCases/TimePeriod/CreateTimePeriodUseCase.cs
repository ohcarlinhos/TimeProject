using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimePeriod;

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