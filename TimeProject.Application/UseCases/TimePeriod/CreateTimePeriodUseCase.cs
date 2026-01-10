using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimePeriod;

public class CreateTimePeriodUseCase(
    ITimePeriodRepository repo,
    IGetTimeRecordByIdUseCase getTimeRecordByIdUseCase,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : ICreateTimePeriodUseCase
{
    public async Task<ICustomResult<PeriodRecord>> Handle(CreateTimePeriodDto dto, int userId)
    {
        var result = new CustomResult<PeriodRecord>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);

        var findTrResult = await getTimeRecordByIdUseCase.Handle(dto.TimeRecordId, userId);
        if (findTrResult.HasError) return result.SetError(findTrResult.Message);

        var data = await repo
            .Create(new Domain.Entities.PeriodRecord
                {
                    UserId = userId,
                    RecordId = dto.TimeRecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            );

        await syncTrMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}