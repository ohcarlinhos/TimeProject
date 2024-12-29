using Entities;
using Shared.General;

namespace Core.TimeRecord.UseCases;

public interface ISyncAllTrMetaUseCase
{
    Task<Result<IEnumerable<TimeRecordMetaEntity>>> Handle();
}