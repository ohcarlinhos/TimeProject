using API.Core.TimeRecord.Repositories;
using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Util;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordMetaRepository(ProjectContext dbContext) : ITimeRecordMetaRepository
{
    public async Task<TimeRecordMetaEntity> CreateOrUpdate(int timeRecordId)
    {
        var timeRecord = await dbContext.TimeRecords.FirstOrDefaultAsync(e => e.Id == timeRecordId);
        var entity = await dbContext.TimeRecordMetas.FirstOrDefaultAsync(e => e.TimeRecordId == timeRecord!.Id);
        var timePeriods = await dbContext.TimePeriods
            .Where(e => e.TimeRecordId == timeRecord!.Id)
            .OrderBy(p => p.Start)
            .ToListAsync();

        var now = DateTime.Now.ToUniversalTime();
        var formattedTime = TimeFormat.StringFromTimePeriods(timePeriods);

        if (entity == null)
        {
            entity = new TimeRecordMetaEntity
            {
                TimeRecordId = timeRecord!.Id,
                TimePeriodCount = timePeriods.Count,
                FormattedTime = formattedTime,
                FirstTimePeriodDate = timePeriods.Count > 0 ? timePeriods[0].Start : null,
                LastTimePeriodDate = timePeriods.Count > 0 ? timePeriods[^1].Start : null,
                CreatedAt = now,
                UpdatedAt = now
            };

            await dbContext.AddAsync(entity);
        }
        else
        {
            entity.TimePeriodCount = timePeriods.Count;
            entity.FormattedTime = formattedTime;
            entity.FirstTimePeriodDate = timePeriods.Count > 0 ? timePeriods[0].Start : null;
            entity.LastTimePeriodDate = timePeriods.Count > 0 ? timePeriods[^1].Start : null;
            entity.UpdatedAt = now;
        }

        await dbContext.SaveChangesAsync();

        return entity;
    }
}