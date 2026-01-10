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

public class UpdateTimePeriodUseCase(
    ITimePeriodRepository repo,
    ISyncTrMetaUseCase syncTrMetaUseCase,
    ITimePeriodValidateUtil timePeriodValidateUtil
) : IUpdateTimePeriodUseCase
{
    public async Task<ICustomResult<PeriodRecord>> Handle(int id, TimePeriodDto dto, int userId)
    {
        var result = new CustomResult<PeriodRecord>();

        timePeriodValidateUtil.ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = await repo.FindById(id, userId);
        if (timePeriod == null) return result.SetError(TimePeriodMessageErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = await repo.Update(timePeriod);
        await syncTrMetaUseCase.Handle(data.RecordId);

        return result.SetData(data);
    }
}