using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Application.UseCases.Records;

public class SyncAllRecordMetaUseCase(
    ProjectContext db,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
)
    : ISyncAllRecordMetaUseCase
{
    public ICustomResult<IEnumerable<IRecordMeta>> Handle()
    {
        var list = db.Records.ToList();
        return new CustomResult<IEnumerable<IRecordMeta>> { Data = syncRecordMetaUseCase.Handle(list, true) };
    }
}