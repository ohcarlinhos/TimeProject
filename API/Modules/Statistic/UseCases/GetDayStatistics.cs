using API.Modules.Statistic.Repository;
using API.Modules.TimePeriod.Util;
using Shared.General;
using Shared.General.Util;
using Shared.Statistic;

namespace API.Modules.Statistic.UseCases;

public class GetDayStatistics(IStatisticRepository repo, ITimePeriodCutUtil timePeriodCutUtil) : IGetDayStatistics
{
    public async Task<Result<DayStatistic>> Handle(int userId, DateTime? date = null, int hoursToAddOnInitDate = 0)
    {
        var result = new Result<DayStatistic>();

        var selectedDate = date?.Date ?? DateTime.Today.ToUniversalTime().Date;

        var initDate = selectedDate.AddHours(hoursToAddOnInitDate);
        var endDate = initDate.AddDays(1);

        var timePeriodListByRange = await repo.GetTimePeriodsByRange(userId, initDate, endDate);
        var timePeriodList = timePeriodCutUtil.Handle(timePeriodListByRange, initDate, endDate);
        var isolatedPeriodList = timePeriodList.Where(e => e.TimerSessionId == null).ToList();

        var sessionList = (await repo.GetTimerSessionsByRange(userId, initDate, endDate))
            .Select(e =>
            {
                e.TimePeriods = timePeriodCutUtil.Handle(e.TimePeriods!, initDate, endDate);
                return e;
            })
            .ToList();

        var timerList = sessionList.Where(e => e.Type == "timer").ToList();
        var pomodoroList = sessionList.Where(e => e.Type == "pomodoro").ToList();
        var breakList = sessionList.Where(e => e.Type == "break").ToList();

        return result.SetData(new DayStatistic
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

            CreatedTimeRecordCount = await repo.TimeRecordCreatedCount(userId, initDate, endDate),
            UpdatedTimeRecordCount = await repo.TimeRecordUpdatedCount(userId, initDate, endDate),
        });
    }
}