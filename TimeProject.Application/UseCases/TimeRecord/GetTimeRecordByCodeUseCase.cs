using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordByCodeUseCase(IRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetTimeRecordByCodeUseCase
{
    public ICustomResult<IRecordOutDto> Handle(string code, int userId)
    {
        var result = new CustomResult<IRecordOutDto>();
        var entity = repo.Details(code, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(mapDataUtil.Handle(entity));
    }
}