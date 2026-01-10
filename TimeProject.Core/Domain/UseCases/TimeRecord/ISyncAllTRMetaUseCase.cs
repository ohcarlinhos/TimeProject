using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ISyncAllTrMetaUseCase
{
    Task<Result<IEnumerable<TimeRecordMetaEntity>>> Handle();
}