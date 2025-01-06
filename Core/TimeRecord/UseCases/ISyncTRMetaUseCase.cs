using Entities;

namespace Core.TimeRecord.UseCases;

public interface ISyncTrMetaUseCase
{
    Task<TimeRecordMetaEntity?> Handle(int id, bool saveChanges = true);
    Task<TimeRecordMetaEntity> Handle(TimeRecordEntity timeRecordEntity, bool saveChanges = false);
    Task<IEnumerable<TimeRecordMetaEntity>> Handle(IEnumerable<TimeRecordEntity> timeRecordEntities,
        bool saveChanges = false);
}