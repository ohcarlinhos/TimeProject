using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodHistoryRepository(ProjectContext db): ITimePeriodHistoryRepository
{
    public async Task<IEnumerable<HistoryDay>> Index(int timeRecordId, int userId, PaginationQuery paginationQuery)
    {
        var timePeriodQuery = db.TimePeriods
            .Where(p => p.UserId == userId && p.TimeRecordId == timeRecordId)
            .AsQueryable();

        var timerSessionQuery = db.TimerSessions
            .Where(p =>
                p.UserId == userId && p.TimeRecordId == timeRecordId && p.TimePeriods != null && p.TimePeriods.Any())
            .AsQueryable();

        var dates = await timePeriodQuery
            .Select((p) => p.Start.Date)
            .Distinct()
            .OrderByDescending(p => p)
            // .Take(9)
            .ToListAsync();

        var timePeriods = await timePeriodQuery
            .Where((p) => p.TimerSessionId == null)
            .ToListAsync();

        var timerSessions = await timerSessionQuery
            .Include(p => p.TimePeriods!
                .OrderBy(q => q.Start))
            .ToListAsync();

        var datedTimeList = new List<HistoryDay>();
        
        foreach (var dateItem in dates)
        {
            var initDate = dateItem.AddHours(3);
            var endDate = initDate.AddDays(1);

            var tpList = timePeriods
                .Where(p => p.Start >= initDate && p.Start < endDate)
                .OrderBy(p => p.Start)
                .ToList();

            var tsList = timerSessions
                .Where(a => a.TimePeriods != null && a.TimePeriods.Any())
                .Where(p =>  p.TimePeriods?.FirstOrDefault()!.Start >= initDate &&
                             p.TimePeriods.FirstOrDefault()!.Start < endDate)
                .ToList();

            datedTimeList.Add(new HistoryDay
            {
                Date = initDate, 
                TimePeriods = tpList, 
                TimerSessions = tsList
            });
        }

        return datedTimeList;
    }
}