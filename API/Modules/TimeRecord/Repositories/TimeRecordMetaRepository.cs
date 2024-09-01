using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Util;

namespace API.Modules.TimeRecord.Repositories;

public class TimeRecordMetaRepository(ProjectContext dbContext) : ITimeRecordMetaRepository
{
    public async Task<TimeRecordMeta> CreateOrUpdate(int timeRecordId)
    {
        var timeRecord = await dbContext.TimeRecords.FirstOrDefaultAsync(e => e.Id == timeRecordId);
        var entity = await dbContext.TimeRecordMetas.FirstOrDefaultAsync(e => e.TimeRecordId == timeRecord!.Id);
        var timePeriods = await dbContext.TimePeriods.Where(e => e.TimeRecordId == timeRecord!.Id).ToListAsync();
        
        var now = DateTime.Now.ToUniversalTime();
        var formattedTime = TimeFormat.StringFromTimePeriods(timePeriods);
        
        if (entity == null)
        {
            entity = new TimeRecordMeta
            {
                TimeRecordId = timeRecord!.Id,
                TimePeriodCount = timePeriods.Count,
                FormattedTime = formattedTime,
                FirstTimePeriodDate = timePeriods[0].Start,
                LastTimePeriodDate = timePeriods[^1].Start,
                CreatedAt = now,
                UpdatedAt = now
            };

            await dbContext.AddAsync(entity);
        }
        else
        {
            entity.TimePeriodCount = timePeriods.Count;
            entity.FormattedTime = formattedTime;
            entity.FirstTimePeriodDate = timePeriods[0].Start;
            entity.LastTimePeriodDate = timePeriods[^1].Start;
            entity.UpdatedAt = now;
        }

        await dbContext.SaveChangesAsync();

        return entity;
    }
}