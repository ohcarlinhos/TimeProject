using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.Repositories;

public class RecordMetaRepository(ProjectContext dbContext) : IRecordMetaRepository
{
    public IRecordMeta? CreateOrUpdate(int timeRecordId, bool saveChanges = true)
    {
        var timeRecord = dbContext.Records.FirstOrDefault(e => e.Id == timeRecordId);
        return timeRecord == null ? null : CreateOrUpdate(timeRecord, saveChanges);
    }

    public IEnumerable<IRecordMeta> CreateOrUpdateList(IEnumerable<IRecord> recordEntities, bool saveChanges = false)
    {
        var list = new List<IRecordMeta>();

        foreach (var timeRecordEntity in recordEntities)
        {
            var meta = CreateOrUpdate(timeRecordEntity, saveChanges);
            if (meta != null) list.Add(meta);
        }

        dbContext.SaveChanges();

        return list;
    }

    public IRecordMeta? CreateOrUpdate(IRecord record, bool saveChanges = true)
    {
        var entity = dbContext.RecordMetas.FirstOrDefault(e => e.RecordId == record.Id);

        var timePeriods = dbContext.PeriodRecords
            .Where(e => e.RecordId == record.Id)
            .OrderBy(e => e.Start)
            .ToList();

        var timeMinutes = dbContext.MinuteRecords
            .Where(e => e.RecordId == record.Id)
            .OrderBy(e => e.Date)
            .ToList();

        var now = DateTime.Now.ToUniversalTime();
        var timeSpan = TimeFormatUtil.TimeSpanFromTimePeriods(timePeriods)
            .Add(TimeFormatUtil.TimeSpanFromTimeMinutes(timeMinutes));
        var formattedTime = TimeFormatUtil.StringFromTimeSpan(timeSpan);

        var firstList = new List<DateTime>();
        var lastList = new List<DateTime>();

        if (timePeriods.Count > 0)
        {
            firstList.Add(timePeriods[0].Start);
            lastList.Add(timePeriods[^1].Start);
        }

        if (timeMinutes.Count > 0)
        {
            firstList.Add(timeMinutes[0].Date);
            lastList.Add(timeMinutes[^1].Date);
        }

        DateTime? first = firstList.Count > 0 ? firstList.OrderBy(i => i).First() : null;
        DateTime? last = lastList.Count > 0 ? lastList.OrderByDescending(i => i).First() : null;

        if (entity == null)
        {
            entity = new RecordMeta
            {
                RecordId = record.Id,
                TimeCount = timePeriods.Count + timeMinutes.Count,
                FormattedTime = formattedTime,
                TimeOnSeconds = timeSpan.TotalSeconds,
                FirstTimeDate = first,
                LastTimeDate = last,
                CreatedAt = now,
                UpdatedAt = now
            };

            dbContext.Add(entity);
        }
        else
        {
            entity.TimeCount = timePeriods.Count + timeMinutes.Count;
            entity.TimeOnSeconds = timeSpan.TotalSeconds;
            entity.FormattedTime = formattedTime;
            entity.FirstTimeDate = first;
            entity.LastTimeDate = last;
            entity.UpdatedAt = now;
        }

        if (saveChanges) dbContext.SaveChanges();

        return entity;
    }
}