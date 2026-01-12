using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimePeriod;

public class CreateTimePeriodUseCase(
    IPeriodRecordRepository repo,
    IGetTimeRecordByIdUseCase getTimeRecordByIdUseCase,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : ICreateTimePeriodUseCase
{
    public ICustomResult<IPeriod> Handle(ICreatePeriodDto dto, int userId)
    {
        var result = new CustomResult<IPeriod>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);

        var findTrResult = getTimeRecordByIdUseCase.Handle(dto.RecordId, userId);
        if (findTrResult.HasError) return result.SetError(findTrResult.Message);

        var data = repo
            .Create(new Period
                {
                    UserId = userId,
                    RecordId = dto.RecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            );

        syncTrMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}