using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordByCodeUseCase(ITimeRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetTimeRecordByCodeUseCase
{
    public async Task<Result<TimeRecordOutDto>> Handle(string code, int userId)
    {
        var result = new Result<TimeRecordOutDto>();
        var entity = await repo.Details(code, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(mapDataUtil.Handle(entity));
    }
}