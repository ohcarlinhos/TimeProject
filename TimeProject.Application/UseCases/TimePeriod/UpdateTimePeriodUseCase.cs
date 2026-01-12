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
using TimeProject.Infrastructure.ObjectValues.Record;

namespace TimeProject.Application.UseCases.TimePeriod;

public class UpdateTimePeriodUseCase(
    IPeriodRecordRepository repo,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : IUpdateTimePeriodUseCase
{
    public ICustomResult<IPeriod> Handle(int id, IPeriodDto dto, int userId)
    {
        var result = new CustomResult<IPeriod>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = repo.FindById(id, userId);
        if (timePeriod == null) return result.SetError(TimePeriodMessageErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = repo.Update(timePeriod);
        syncTrMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}