using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISyncAllTrMetaUseCase
{
    Task<Result<IEnumerable<TimeRecordMetaEntity>>> Handle();
}