using Core.Statistic;
using Core.Statistic.UseCases;
using Core.TimePeriod.Utils;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.Utils;
using Shared.General;
using Shared.General.Util;
using Shared.Statistic;

namespace App.Modules.Statistic.UseCases;

public class GetDayStatisticUseCase(
    IStatisticRepository statisticRepository,
    ITimeRecordRepository timeRecordRepository,
    ITimePeriodCutUtil timePeriodCutUtil,
    ITimeRecordMapDataUtil mapDataUtil
)
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

        var selectedDate = date ?? DateTime.Today.ToUniversalTime();

        var initDate = selectedDate.AddHours(hoursToAddOnInitDate);
        var endDate = initDate.AddDays(1);

        var timePeriodListByRange =
            await statisticRepository.GetTimePeriodsByRange(userId, initDate, endDate, timeRecordId);
        var timePeriodList = timePeriodCutUtil.Handle(timePeriodListByRange, initDate, endDate);
        var isolatedPeriodList = timePeriodList.Where(e => e.TimerSessionId == null).ToList();

        var sessionList = (await statisticRepository.GetTimerSessionsByRange(userId, initDate, endDate, timeRecordId))
            .Select(e =>
            {
                e.TimePeriods = timePeriodCutUtil.Handle(e.TimePeriods!, initDate, endDate);
                return e;
            })
            .ToList();

        var timerList = sessionList.Where(e => e.Type == "timer").ToList();
        var pomodoroList = sessionList.Where(e => e.Type == "pomodoro").ToList();
        var breakList = sessionList.Where(e => e.Type == "break").ToList();

        var timeMinuteList = await statisticRepository.GetTimeMinutesByRange(userId, initDate, endDate, timeRecordId);

        var allPeriodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(timePeriodList);
        var isolatedPeriodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(isolatedPeriodList);
        var timeMinutesTimeSpan = TimeFormat.TimeSpanFromTimeMinutes(timeMinuteList);

        var timeRecordIdList = new List<int>();
        timeRecordIdList.AddRange(timePeriodList.Select(e => e.TimeRecordId));
        timeRecordIdList.AddRange(timeMinuteList.Select(e => e.TimeRecordId));

        var timeRecords = await timeRecordRepository.FindByIdList(timeRecordIdList.Distinct().ToList(), userId);
        var trRangeProgressList = new List<TimeRecordRangeProgress>();

        foreach (var tr in timeRecords)
        {
            var trPeriods = timePeriodListByRange
                .Where(e => e.TimeRecordId == tr.Id)
                .ToList();

            var trMinutes = timeMinuteList
                .Where(e => e.TimeRecordId == tr.Id)
                .ToList();

            var trPeriodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(trPeriods);
            var trMinutesTimeSpan = TimeFormat.TimeSpanFromTimeMinutes(trMinutes);

            trRangeProgressList.Add(new TimeRecordRangeProgress()
            {
                TimePeriods = trPeriods,
                TimeMinutes = trMinutes,
                TimeRecord = mapDataUtil.Handle(tr),
                TotalHours = TimeFormat.StringFromTimeSpan(trPeriodsTimeSpan.Add(trMinutesTimeSpan)),
                TotalTimeSpan = trPeriodsTimeSpan.Add(trMinutesTimeSpan)
            });
        }

        return result.SetData(new DayStatistic
        {
            StartDay = initDate,
            EndDay = endDate,

            TotalHours = TimeFormat.StringFromTimeSpan(allPeriodsTimeSpan.Add(timeMinutesTimeSpan)),
            TotalIsolatedPeriodHours = TimeFormat.StringFromTimePeriods(isolatedPeriodList),
            TotalTimerHours = TimeFormat.StringFromTimerSessions(timerList),
            TotalPomodoroHours = TimeFormat.StringFromTimerSessions(pomodoroList),
            TotalBreakHours = TimeFormat.StringFromTimerSessions(breakList),
            TotalTimeMinutesHours = TimeFormat.StringFromTimeSpan(TimeFormat.TimeSpanFromTimeMinutes(timeMinuteList)),
            TotalTimeManual = TimeFormat.StringFromTimeSpan(isolatedPeriodsTimeSpan.Add(timeMinutesTimeSpan)),

            TimerCount = timerList.Count,
            PomodoroCount = pomodoroList.Count,
            BreakCount = breakList.Count,
            IsolatedPeriodCount = isolatedPeriodList.Count,
            ManualCount = isolatedPeriodList.Count + timeMinuteList.Count,

            TimePeriodCount = timePeriodList.Count,
            InterruptionCount = timePeriodList.Count > 0 ? timePeriodList.Count - 1 : 0,
            SessionCount = sessionList.Count,
            TimeMinuteCount = timeMinuteList.Count,

            CreatedTimeRecordCount = timeRecordId == null
                ? await statisticRepository.GetTimeRecordCreatedCount(userId, initDate, endDate)
                : 0,
            UpdatedTimeRecordCount = timeRecordId == null
                ? await statisticRepository.GetTimeRecordUpdatedCount(userId, initDate, endDate)
                : 0,
            TimeRecordRangeProgress = trRangeProgressList.OrderByDescending(i => i.TotalTimeSpan).ToList()
        });
    }
}