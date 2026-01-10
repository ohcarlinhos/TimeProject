using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimePeriod;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;

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