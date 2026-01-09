using Core.Statistic;
using Core.Statistic.UseCases;
using Core.TimePeriod.Utils;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.Utils;
using Entities;
using Shared.General;
using Shared.General.Util;
using Shared.Statistic;

namespace TimeProject.Api.Modules.Statistic.UseCases;

public class GetRangeDaysStatisticUseCase(
    IStatisticRepository statisticRepository,
    ITimeRecordRepository timeRecordRepository,
    ITimePeriodCutUtil timePeriodCutUtil,
    ITimeRecordMapDataUtil mapDataUtil
)
    : IGetRangeDaysStatisticUseCase
{
    public async Task<Result<RangeStatistic>> Handle(
        int userId,
        DateTime? start = null,
        DateTime? end = null,
        int? timeRecordId = null,
        bool skipRangeProgress = false
    )
    {
        return new Result<RangeStatistic>().SetData(
            (await _handle(userId, start, end, timeRecordId, skipRangeProgress)).Statistic
        );
    }

    public async Task<Result<RangeStatisticsWithDays>> Handle(int userId, DateTime start, DateTime end)
    {
        var daysFromRange = new List<DateTime> { start };
        var daysStatistics = new List<RangeStatistic>();

        var allTimePeriods = new List<TimePeriodEntity>();
        var timeMinutes = new List<TimeMinuteEntity>();
        var allTimerSessions = new List<TimerSessionEntity>();

        var startDate = start.AddDays(1);

        while (startDate < end)
        {
            daysFromRange.Add(startDate);
            startDate = startDate.AddDays(1);
        }

        daysFromRange.Add(end);

        var daysCount = daysFromRange.Count;
        var activeDaysCount = 0;

        foreach (var day in daysFromRange)
        {
            var result = await _handle(userId, day, null, null, true);
            allTimePeriods.AddRange(result.TimePeriods);
            timeMinutes.AddRange(result.TimeMinutes);
            allTimerSessions.AddRange(result.Sessions);
            daysStatistics.Add(result.Statistic);
            if (result.Statistic.TotalInMinutes > 0) activeDaysCount++;
        }

        var rangeStatistics = MakeRangeStatisticDatas(
            start,
            end,
            allTimePeriods,
            timeMinutes,
            allTimerSessions,
            new List<TimeRecordEntity>(),
            daysCount,
            activeDaysCount
        ).Statistic;

        rangeStatistics.TimeRecordRangeProgress = MakeRangeProgress(
            await GetTimeRecordsByRange(userId, allTimePeriods, timeMinutes),
            allTimePeriods,
            timeMinutes
        );


        return new Result<RangeStatisticsWithDays>().SetData(new RangeStatisticsWithDays
        {
            Total = rangeStatistics,
            Days = daysStatistics.OrderByDescending(e => e.StartDay).ToList()
        });
    }

    private async Task<RangeStatisticsData> _handle(
        int userId,
        DateTime? start = null,
        DateTime? end = null,
        int? timeRecordId = null,
        bool skipRangeProgress = false
    )
    {
        var initDate = start ?? DateTime.Today.ToUniversalTime();
        var endDate = end ?? initDate.AddDays(1).AddMicroseconds(-1);

        var timePeriodsByRange = await statisticRepository
            .GetTimePeriodsByRange(userId, initDate, endDate, timeRecordId);

        var timePeriods = timePeriodCutUtil.Handle(timePeriodsByRange, initDate, endDate);

        var allTimerSessions =
            (await statisticRepository.GetTimerSessionsByRange(userId, initDate, endDate, timeRecordId))
            .Select(e =>
            {
                e.TimePeriods = timePeriodCutUtil.Handle(e.TimePeriods!, initDate, endDate);
                return e;
            })
            .ToList();

        var timeMinutes = await statisticRepository.GetTimeMinutesByRange(userId, initDate, endDate, timeRecordId);

        var timeRecords = new List<TimeRecordEntity>();
        if (timeRecordId == null && !skipRangeProgress)
        {
            var trIdList = new List<int>();
            trIdList.AddRange(timePeriods.Select(e => e.TimeRecordId));
            trIdList.AddRange(timeMinutes.Select(e => e.TimeRecordId));
            timeRecords.AddRange(await timeRecordRepository.FindByIdList(trIdList.Distinct().ToList(), userId));
        }

        return MakeRangeStatisticDatas(
            initDate,
            endDate,
            timePeriods,
            timeMinutes,
            allTimerSessions,
            timeRecords
        );
    }

    private RangeStatisticsData MakeRangeStatisticDatas(
        DateTime start,
        DateTime end,
        List<TimePeriodEntity> allTimePeriods,
        List<TimeMinuteEntity> timeMinutes,
        List<TimerSessionEntity> allTimerSessions,
        List<TimeRecordEntity> timeRecords,
        int daysCount = 0,
        int activeDaysCount = 0
    )
    {
        var isolatedPeriods = allTimePeriods.Where(e => e.TimerSessionId == null).ToList();

        var timerSessions = allTimerSessions.Where(e => e.Type == "timer").ToList();
        var pomodoroSessions = allTimerSessions.Where(e => e.Type == "pomodoro").ToList();
        var breakSessions = allTimerSessions.Where(e => e.Type == "break").ToList();

        var allPeriodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(allTimePeriods);
        var isolatedPeriodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(isolatedPeriods);
        var timeMinutesTimeSpan = TimeFormat.TimeSpanFromTimeMinutes(timeMinutes);

        var totalTimeSpan = allPeriodsTimeSpan.Add(timeMinutesTimeSpan);
        var totalManualTimeSpan = isolatedPeriodsTimeSpan.Add(timeMinutesTimeSpan);
        var totalSessionTimeSpan = TimeFormat.TimeSpanFromTimerSessions(allTimerSessions);

        var rangeProgress = MakeRangeProgress(timeRecords, allTimePeriods, timeMinutes);

        var totalDays = (end - start).TotalDays;
        if (totalDays == 0) totalDays = 1;

        var hoursAvarege = activeDaysCount != 0
            ? totalTimeSpan.TotalHours / activeDaysCount
            : totalTimeSpan.TotalHours / totalDays;

        var minutesAvarege = activeDaysCount != 0
            ? totalTimeSpan.TotalMinutes / activeDaysCount
            : totalTimeSpan.TotalMinutes / totalDays;

        var avarageTimeSpan = TimeSpan.FromHours(hoursAvarege);

        return new RangeStatisticsData
        {
            TimePeriods = allTimePeriods,
            TimeMinutes = timeMinutes,
            Sessions = allTimerSessions,
            Statistic = new RangeStatistic
            {
                StartDay = start,
                EndDay = end,

                TotalHours = TimeFormat.StringFromTimeSpan(totalTimeSpan),
                ManualHours = TimeFormat.StringFromTimeSpan(totalManualTimeSpan),
                TimeMinuteHours = TimeFormat.StringFromTimeSpan(timeMinutesTimeSpan),
                IsolatedPeriodHours = TimeFormat.StringFromTimePeriods(isolatedPeriods),

                TotalInHours = totalTimeSpan.TotalHours,
                TotalInMinutes = totalTimeSpan.TotalMinutes,

                AverageInHours = hoursAvarege,
                AverageInMinutes = minutesAvarege,
                AverageHours = TimeFormat.StringFromTimeSpan(avarageTimeSpan),

                DaysCount = daysCount,
                ActiveDaysCount = activeDaysCount,

                TimerHours = TimeFormat.StringFromTimerSessions(timerSessions),
                PomodoroHours = TimeFormat.StringFromTimerSessions(pomodoroSessions),
                BreakHours = TimeFormat.StringFromTimerSessions(breakSessions),

                TotalTimeSpan = totalTimeSpan,
                IsolatedPeriodsTimeSpan = isolatedPeriodsTimeSpan,
                TimeMinutesTimeSpan = timeMinutesTimeSpan,
                SessionsTimeSpan = totalSessionTimeSpan,

                TimerCount = timerSessions.Count,
                PomodoroCount = pomodoroSessions.Count,
                BreakCount = breakSessions.Count,
                IsolatedPeriodCount = isolatedPeriods.Count,
                ManualCount = isolatedPeriods.Count + timeMinutes.Count,

                TimePeriodCount = allTimePeriods.Count,
                SessionCount = allTimerSessions.Count,
                TimeMinuteCount = timeMinutes.Count,

                TimeRecordRangeProgress = rangeProgress
            }
        };
    }

    private List<TimeRecordRangeProgress> MakeRangeProgress(
        List<TimeRecordEntity> timeRecords,
        List<TimePeriodEntity> allTimePeriods,
        List<TimeMinuteEntity> allTimeMinutes
    )
    {
        var rangeProgressList = new List<TimeRecordRangeProgress>();

        foreach (var tr in timeRecords)
        {
            var periods = allTimePeriods
                .Where(e => e.TimeRecordId == tr.Id)
                .ToList();

            var minutes = allTimeMinutes
                .Where(e => e.TimeRecordId == tr.Id)
                .ToList();

            var periodsTimeSpan = TimeFormat.TimeSpanFromTimePeriods(periods);
            var minutesTimeSpan = TimeFormat.TimeSpanFromTimeMinutes(minutes);
            var totalHoursTimeSpan = periodsTimeSpan.Add(minutesTimeSpan);

            rangeProgressList.Add(new TimeRecordRangeProgress
            {
                TimeRecord = mapDataUtil.Handle(tr),
                TotalHours = TimeFormat.StringFromTimeSpan(totalHoursTimeSpan),
                TotalTimeSpan = totalHoursTimeSpan
            });
        }

        return rangeProgressList.OrderByDescending(i => i.TotalTimeSpan).ToList();
    }

    private Task<List<TimeRecordEntity>> GetTimeRecordsByRange(
        int userId,
        List<TimePeriodEntity> allTimePeriods,
        List<TimeMinuteEntity> allTimeMinutes
    )
    {
        var trIdList = new List<int>();
        trIdList.AddRange(allTimePeriods.Select(e => e.TimeRecordId));
        trIdList.AddRange(allTimeMinutes.Select(e => e.TimeRecordId));
        return timeRecordRepository.FindByIdList(trIdList.Distinct().ToList(), userId);
    }
}