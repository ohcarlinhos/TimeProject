using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ISyncAllTrMetaUseCase
{
    Task<Result<IEnumerable<TimeRecordMetaEntity>>> Handle();
}