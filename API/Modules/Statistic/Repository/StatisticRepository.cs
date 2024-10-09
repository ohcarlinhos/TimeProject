using API.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.General.Util;
using Shared.Statistic;

namespace API.Modules.Statistic.Repository;

public class StatisticRepository(ProjectContext db) : IStatisticRepository
{
    public async Task<DayStatistic> GetDay(DateTime date, int userId)
    {
        var initDate = date.AddHours(3);
        var endDate = initDate.AddDays(1);

        var timePeriodSelect = await db.TimePeriods
            .Where(e => e.Start >= initDate && e.Start < endDate && userId == e.UserId)
            .Select(e => new { e.Start, e.End, e.TimerSessionId })
            .ToListAsync();

        var timePeriodList = timePeriodSelect
            .Select(e => new TimePeriodEntity { Start = e.Start, End = e.End, TimerSessionId = e.TimerSessionId })
            .ToList();

        var isolatedPeriodList = timePeriodList
            .Where(e => e.TimerSessionId == null)
            .ToList();
        
        var sessionList = await db.TimerSessions
            .Where(e => e.CreatedAt >= initDate && e.CreatedAt < endDate && userId == e.UserId)
            .Include(e => e.TimePeriods)
            .ToListAsync();

        var timerList = sessionList.Where(e => e.Type == "timer").ToList();
        var pomodoroList = sessionList.Where(e => e.Type == "pomodoro").ToList();
        var breakList = sessionList.Where(e => e.Type == "break").ToList();

        var timeRecordCreatedCount = await db.TimeRecords
            .Where((e) => e.CreatedAt >= initDate && e.CreatedAt < endDate && userId == e.UserId)
            .CountAsync();

        var timeRecordUpdatedCount = await db.TimeRecords
            .Where((e) => e.UpdatedAt >= initDate && e.UpdatedAt < endDate && userId == e.UserId)
            .CountAsync();

        return new DayStatistic
        {
            StartDay = initDate,
            EndDay = endDate,

            TotalHours = TimeFormat.StringFromTimePeriods(timePeriodList),
            TotalIsolatedPeriodHours = TimeFormat.StringFromTimePeriods(isolatedPeriodList),

            TotalTimerHours = TimeFormat.StringFromTimerSessions(timerList),
            TotalPomodoroHours = TimeFormat.StringFromTimerSessions(pomodoroList),
            TotalBreakHours = TimeFormat.StringFromTimerSessions(breakList),

            TimePeriodCount = timePeriodList.Count,
            InterruptionCount = timePeriodList.Count > 0 ? timePeriodList.Count - 1 : 0,
            SessionCount = sessionList.Count,

            IsolatedPeriodCount = isolatedPeriodList.Count,
            TimerCount = timerList.Count,
            PomodoroCount = pomodoroList.Count,
            BreakCount = breakList.Count,

            CreatedTimeRecordCount = timeRecordCreatedCount,
            UpdatedTimeRecordCount = timeRecordUpdatedCount,
        };
    }
}