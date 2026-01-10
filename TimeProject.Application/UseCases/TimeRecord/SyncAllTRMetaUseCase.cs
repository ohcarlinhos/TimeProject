using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Application.UseCases.TimeRecord;

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