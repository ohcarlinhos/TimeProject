using Core.TimeRecord.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Util;
using TimeProject.Api.Database;

namespace TimeProject.Api.Modules.TimeRecord.Repositories;

public class TimeRecordMetaRepository(ProjectContext dbContext) : ITimeRecordMetaRepository
{
    public async Task<TimeRecordMetaEntity?> CreateOrUpdate(int timeRecordId, bool saveChanges = true)
    {
        var timeRecord = await dbContext.TimeRecords.FirstOrDefaultAsync(e => e.Id == timeRecordId);
        return timeRecord == null ? null : await CreateOrUpdate(timeRecord, saveChanges);
    }

    public async Task<IEnumerable<TimeRecordMetaEntity>> CreateOrUpdateList(
        IEnumerable<TimeRecordEntity> timeRecordEntities, bool saveChanges = false)
    {
        var list = new List<TimeRecordMetaEntity>();

        foreach (var timeRecordEntity in timeRecordEntities)
        {
            var meta = await CreateOrUpdate(timeRecordEntity, saveChanges);
            if (meta != null) list.Add(meta);
        }

        await dbContext.SaveChangesAsync();

        return list;
    }

    public async Task<TimeRecordMetaEntity?> CreateOrUpdate(TimeRecordEntity timeRecord, bool saveChanges = true)
    {
        var entity = await dbContext.TimeRecordMetas.FirstOrDefaultAsync(e => e.TimeRecordId == timeRecord.Id);

        var timePeriods = await dbContext.TimePeriods
            .Where(e => e.TimeRecordId == timeRecord.Id)
            .OrderBy(e => e.Start)
            .ToListAsync();

        var timeMinutes = await dbContext.TimeMinutes
            .Where(e => e.TimeRecordId == timeRecord.Id)
            .OrderBy(e => e.Date)
            .ToListAsync();

        var now = DateTime.Now.ToUniversalTime();
        var timeSpan = TimeFormat.TimeSpanFromTimePeriods(timePeriods)
            .Add(TimeFormat.TimeSpanFromTimeMinutes(timeMinutes));
        var formattedTime = TimeFormat.StringFromTimeSpan(timeSpan);

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
            entity = new TimeRecordMetaEntity
            {
                TimeRecordId = timeRecord.Id,
                TimeCount = timePeriods.Count + timeMinutes.Count,
                FormattedTime = formattedTime,
                TimeOnSeconds = timeSpan.TotalSeconds,
                FirstTimeDate = first,
                LastTimeDate = last,
                CreatedAt = now,
                UpdatedAt = now
            };

            await dbContext.AddAsync(entity);
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

        if (saveChanges) await dbContext.SaveChangesAsync();

        return entity;
    }
}