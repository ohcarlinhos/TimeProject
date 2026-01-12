using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Records;

public class GetRecordByCodeUseCase(IRecordRepository repo, IRecordMapDataUtil mapDataUtil)
    : IGetRecordByCodeUseCase
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