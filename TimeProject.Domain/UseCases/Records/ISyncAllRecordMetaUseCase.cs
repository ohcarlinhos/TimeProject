using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface ISyncAllRecordMetaUseCase
{
    ICustomResult<IEnumerable<IRecordMeta>> Handle();
}