using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimePeriod;

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
        if (timePeriod == null) return result.SetError(TimePeriodMessageErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = await repo.Update(timePeriod);
        await syncTrMetaUseCase.Handle(data.TimeRecordId);

        return result.SetData(data);
    }
}