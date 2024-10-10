using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared.General.Pagination;
using Shared.General.Repositories;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Repositories;

public class TimePeriodHistoryRepository(ProjectContext db) : ITimePeriodHistoryRepository
{
    public async Task<IndexRepositoryResult<HistoryDay>> Index(int timeRecordId, int userId,
        PaginationQuery paginationQuery)
    {
        var timePeriodQuery = db.TimePeriods
            .Where(p => p.UserId == userId && p.TimeRecordId == timeRecordId)
            .AsQueryable();

        var timerSessionQuery = db.TimerSessions
            .Where(p =>
                p.UserId == userId && p.TimeRecordId == timeRecordId && p.TimePeriods != null && p.TimePeriods.Any())
            .AsQueryable();

        var datesFromQuery = await timePeriodQuery
            .Select(p => p.Start)
            .OrderByDescending(p => p)
            .ToListAsync();

        var distinctDate = datesFromQuery
            .Select(e => e.AddHours(-3).Date)
            .Distinct()
            .ToList();

        var dates = distinctDate
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .ToList();

        var datedTimeList = new List<HistoryDay>();

        foreach (var dateItem in dates)
        {
            var initDate = dateItem.AddHours(3);
            var endDate = initDate.AddDays(1);

            var tpList = await timePeriodQuery
                .Where(p => p.Start >= initDate && p.Start < endDate && p.TimerSessionId == null)
                .OrderBy(p => p.Start)
                .ToListAsync();

            var tsList = await timerSessionQuery
                .Where(p => p.TimePeriods!.FirstOrDefault()!.Start >= initDate &&
                            p.TimePeriods!.FirstOrDefault()!.Start < endDate)
                .Include(p => p.TimePeriods!
                    .OrderBy(q => q.Start))
                .ToListAsync();

            if (tpList.Any() || tsList.Any())
            {
                datedTimeList.Add(new HistoryDay
                {
                    Date = initDate,
                    TimePeriods = tpList,
                    TimerSessions = tsList
                });
            }
        }

        return new IndexRepositoryResult<HistoryDay>
        {
            Count = distinctDate.Count(),
            Entities = datedTimeList
        };
    }
}