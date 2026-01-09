using Core.TimeRecord.UseCases;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General;
using TimeProject.Api.Database;

namespace TimeProject.Api.Modules.TimeRecord.UseCases;

public class SyncAllTrMetaUseCase(
    ProjectContext db,
    ISyncTrMetaUseCase syncTrMetaUseCase
)
    : ISyncAllTrMetaUseCase
{
    public async Task<Result<IEnumerable<TimeRecordMetaEntity>>> Handle()
    {
        IEnumerable<TimeRecordEntity> list = await db.TimeRecords.ToListAsync();
        return new Result<IEnumerable<TimeRecordMetaEntity>> { Data = await syncTrMetaUseCase.Handle(list, true) };
    }
}