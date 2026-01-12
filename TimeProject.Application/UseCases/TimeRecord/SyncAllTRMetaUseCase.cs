using Microsoft.EntityFrameworkCore;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SyncAllTrMetaUseCase(
    ProjectContext db,
    ISyncTrMetaUseCase syncTrMetaUseCase
)
    : ISyncAllTrMetaUseCase
{
    public async Task<ICustomResult<IEnumerable<RecordMeta>>> Handle()
    {
        IEnumerable<Infrastructure.Entities.Record> list = await db.Records.ToListAsync();
        return new CustomResult<IEnumerable<RecordMeta>> { Data = await syncTrMetaUseCase.Handle(list, true) };
    }
}