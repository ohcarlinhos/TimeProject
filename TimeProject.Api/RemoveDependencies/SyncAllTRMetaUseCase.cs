using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Api.RemoveDependencies;

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