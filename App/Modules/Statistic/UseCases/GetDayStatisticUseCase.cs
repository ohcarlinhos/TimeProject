using Core.Statistic;
using Core.Statistic.UseCases;
using Core.TimePeriod.Utils;
using Shared.General;
using Shared.General.Util;
using Shared.Statistic;

namespace App.Modules.Statistic.UseCases;

public class GetDayStatisticUseCase(IStatisticRepository repository, ITimePeriodCutUtil timePeriodCutUtil)
    : IGetDayStatisticUseCase
{
    public async Task<Result<DayStatistic>> Handle(
        int userId,
        DateTime? date = null,
        int hoursToAddOnInitDate = 0,
        int? timeRecordId = null
    )
    {
        var result = new Result<DayStatistic>();

        var selectedDate = date?.Date ?? DateTime.Today.ToUniversalTime().Date;

        var initDate = selectedDate.AddHours(hoursToAddOnInitDate);
        var endDate = initDate.AddDays(1);

        var timePeriodListByRange = await repository.GetTimePeriodsByRange(userId, initDate, endDate, timeRecordId);
        var timePeriodList = timePeriodCutUtil.Handle(timePeriodListByRange, initDate, endDate);
        var isolatedPeriodList = timePeriodList.Where(e => e.TimerSessionId == null).ToList();

        var sessionList = (await repository.GetTimerSessionsByRange(userId, initDate, endDate, timeRecordId))
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

            IsolatedPeriodCount = isolatedPeriodList.Count,
            TimerCount = timerList.Count,
            PomodoroCount = pomodoroList.Count,
            BreakCount = breakList.Count,

            TimePeriodCount = timePeriodList.Count,
            InterruptionCount = timePeriodList.Count > 0 ? timePeriodList.Count - 1 : 0,
            SessionCount = sessionList.Count,

            CreatedTimeRecordCount = timeRecordId == null
                ? await repository.TimeRecordCreatedCount(userId, initDate, endDate)
                : 0,
            UpdatedTimeRecordCount = timeRecordId == null
                ? await repository.TimeRecordUpdatedCount(userId, initDate, endDate)
                : 0,
        });
    }
}