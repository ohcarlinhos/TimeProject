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
using TimeProject.Infrastructure.ObjectValues.Records;

namespace TimeProject.Application.UseCases.Periods;

public class UpdatePeriodUseCase(
    IPeriodRepository repository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase,
    IPeriodValidateUtil periodValidateUtil
) : IUpdatePeriodUseCase
{
    public ICustomResult<IPeriod> Handle(int id, IPeriodDto dto, int userId)
    {
        var result = new CustomResult<IPeriod>();

        periodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = repository.FindById(id, userId);
        if (timePeriod == null) return result.SetError(TimePeriodMessageErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = repository.Update(timePeriod);
        syncRecordMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}