using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Periods;

public class CreatePeriodUseCase(
    IPeriodRepository repository,
    IGetRecordByIdUseCase getRecordByIdUseCase,
    ISyncRecordMetaUseCase syncRecordMetaUseCase,
    IPeriodValidateUtil periodValidateUtil
) : ICreatePeriodUseCase
{
    public ICustomResult<IPeriod> Handle(ICreatePeriodDto dto, int userId)
    {
        var result = new CustomResult<IPeriod>();

        periodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);

        var findTrResult = getRecordByIdUseCase.Handle(dto.RecordId, userId);
        if (findTrResult.HasError) return result.SetError(findTrResult.Message);

        var data = repository
            .Create(new Period
                {
                    UserId = userId,
                    RecordId = dto.RecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            );

        syncRecordMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}