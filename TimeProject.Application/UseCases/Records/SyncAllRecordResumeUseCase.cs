using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Application.UseCases.Records;

public class SyncAllRecordResumeUseCase(
    CustomDbContext db,
    ISyncRecordResumeUseCase syncRecordResumeUseCase
)
    : ISyncAllRecordResumeUseCase
{
    public ICustomResult<IEnumerable<IRecordResume>> Handle()
    {
        var list = db.Records.ToList();
        return new CustomResult<IEnumerable<IRecordResume>> { Data = syncRecordResumeUseCase.Handle(list, true) };
    }
}