using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.Repositories;

public class RecordMetaRepository(CustomDbContext db) : IRecordMetaRepository
{
    public IRecordMeta? CreateOrUpdate(int recordId, bool saveChanges = true)
    {
        var record = db.Records.FirstOrDefault(e => e.Id == recordId);
        return record == null ? null : CreateOrUpdate(record, saveChanges);
    }

    public IEnumerable<IRecordMeta> CreateOrUpdateList(IEnumerable<IRecord> recordEntities, bool saveChanges = false)
    {
        var list = new List<IRecordMeta>();

        foreach (var recordEntity in recordEntities)
        {
            var meta = CreateOrUpdate(recordEntity, saveChanges);
            if (meta != null) list.Add(meta);
        }

        db.SaveChanges();

        return list;
    }

    public IRecordMeta? CreateOrUpdate(IRecord record, bool saveChanges = true)
    {
        var entity = db.RecordMetas.FirstOrDefault(e => e.RecordId == record.Id);

        var periods = db.Periods
            .Where(e => e.RecordId == record.Id)
            .OrderBy(e => e.Start)
            .ToList();

        var timeMinutes = db.Minutes
            .Where(e => e.RecordId == record.Id)
            .OrderBy(e => e.Date)
            .ToList();

        var now = DateTime.Now.ToUniversalTime();
        var timeSpan = TimeFormatUtil.TimeSpanFromPeriods(periods)
            .Add(TimeFormatUtil.TimeSpanFromMinutes(timeMinutes));
        var formattedTime = TimeFormatUtil.StringFromTimeSpan(timeSpan);

        var firstList = new List<DateTime>();
        var lastList = new List<DateTime>();

        if (periods.Count > 0)
        {
            firstList.Add(periods[0].Start);
            lastList.Add(periods[^1].Start);
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
                TimeCount = periods.Count + timeMinutes.Count,
                FormattedTime = formattedTime,
                TimeOnSeconds = timeSpan.TotalSeconds,
                FirstTimeDate = first,
                LastTimeDate = last,
                CreatedAt = now,
                UpdatedAt = now
            };

            db.Add(entity);
        }
        else
        {
            entity.TimeCount = periods.Count + timeMinutes.Count;
            entity.TimeOnSeconds = timeSpan.TotalSeconds;
            entity.FormattedTime = formattedTime;
            entity.FirstTimeDate = first;
            entity.LastTimeDate = last;
            entity.UpdatedAt = now;
        }

        if (saveChanges) db.SaveChanges();

        return entity;
    }
}