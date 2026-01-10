using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISyncAllTrMetaUseCase
{
    Task<ICustomResult<IEnumerable<RecordMeta>>> Handle();
}