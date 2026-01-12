using Microsoft.EntityFrameworkCore;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
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
    public ICustomResult<IEnumerable<IRecordMeta>> Handle()
    {
        var list = db.Records.ToList();
        return new CustomResult<IEnumerable<IRecordMeta>> { Data = syncTrMetaUseCase.Handle(list, true) };
    }
}