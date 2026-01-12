using TimeProject.Application.ObjectValues;
using TimeProject.Application.UseCases.TimePeriod.Utils;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Statistic;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Application.UseCases.Statistic;

public class GetRangeDaysStatisticUseCase(
    IStatisticRepository statisticRepository,
    IRecordRepository recordRepository,
    ITimePeriodCutUtil timePeriodCutUtil,
    ITimeRecordMapDataUtil mapDataUtil
)
    : IGetRangeDaysStatisticUseCase
{
    public ICustomResult<IRangeStatistic> Handle(
        int userId,
        DateTime? start = null,
        DateTime? end = null,
        int? timeRecordId = null,
        bool skipRangeProgress = false
    )
    {
        return new CustomResult<IRangeStatistic>().SetData(
            (_handle(userId, start, end, timeRecordId, skipRangeProgress)).Statistic
        );
    }

    public ICustomResult<IRangeStatisticsWithDays> Handle(int userId, DateTime start, DateTime end)
    {
        var daysFromRange = new List<DateTime> { start };
        var daysStatistics = new List<IRangeStatistic>();

        var allTimePeriods = new List<PeriodRecord>();
        var timeMinutes = new List<MinuteRecord>();
        var allTimerSessions = new List<RecordSession>();

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
            var result = _handle(userId, day, null, null, true);
            allTimePeriods.AddRange((result.TimePeriods as IList<PeriodRecord>)!);
            timeMinutes.AddRange((result.TimeMinutes as IList<MinuteRecord>)!);
            allTimerSessions.AddRange((result.Sessions as IList<RecordSession>)!);
            daysStatistics.Add((RangeStatistic)result.Statistic);
            if (result.Statistic.TotalInMinutes > 0) activeDaysCount++;
        }

        var rangeStatistics = MakeRangeStatisticDatas(
            start,
            end,
            allTimePeriods,
            timeMinutes,
            allTimerSessions,
            new List<Record>(),
            daysCount,
            activeDaysCount
        ).Statistic;

        rangeStatistics.TimeRecordRangeProgress = MakeRangeProgress(
            GetTimeRecordsByRange(userId, allTimePeriods, timeMinutes),
            allTimePeriods,
            timeMinutes
        );


        return new CustomResult<IRangeStatisticsWithDays>().SetData(new RangeStatisticsWithDays
        {
            Total = rangeStatistics,
            Days = daysStatistics.OrderByDescending(e => e.StartDay).ToList()
        });
    }

    private RangeStatisticsData _handle(
        int userId,
        DateTime? start = null,
        DateTime? end = null,
        int? timeRecordId = null,
        bool skipRangeProgress = false
    )
    {
        var initDate = start ?? DateTime.Today.ToUniversalTime();
        var endDate = end ?? initDate.AddDays(1).AddMicroseconds(-1);

        var timePeriodsByRange = statisticRepository
            .GetTimePeriodsByRange(userId, initDate, endDate, timeRecordId);

        var timePeriods = timePeriodCutUtil.Handle(timePeriodsByRange as List<PeriodRecord>, initDate, endDate);

        var allTimerSessions =
            (statisticRepository.GetTimerSessionsByRange(userId, initDate, endDate,
                timeRecordId) as List<RecordSession>)
            .Select(e =>
            {
                e.PeriodRecords = timePeriodCutUtil.Handle(e.PeriodRecords!, initDate, endDate);
                return e;
            })
            .ToList();

        var timeMinutes = statisticRepository.GetTimeMinutesByRange(userId, initDate, endDate, timeRecordId) as List<MinuteRecord>;

        var timeRecords = new List<Record>();
        if (timeRecordId == null && !skipRangeProgress)
        {
            var trIdList = new List<int>();
            trIdList.AddRange(timePeriods.Select(e => e.RecordId));
            trIdList.AddRange(timeMinutes.Select(e => e.RecordId));
            timeRecords.AddRange(recordRepository.FindByIdList(trIdList.Distinct().ToList(), userId) as List<Record>);
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
        IList<PeriodRecord> allTimePeriods,
        IList<MinuteRecord> timeMinutes,
        IList<RecordSession> allTimerSessions,
        IList<Record> timeRecords,
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
            TimePeriods = (allTimePeriods as IList<IPeriodRecord>)!,
            TimeMinutes = (timeMinutes as IList<IMinuteRecord>)!,
            Sessions = (allTimerSessions as IList<IRecordSession>)!,
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

    private IList<ITimeRecordRangeProgress> MakeRangeProgress(
        IList<Record> timeRecords,
        IList<PeriodRecord> allTimePeriods,
        IList<MinuteRecord> allTimeMinutes
    )
    {
        var rangeProgressList = new List<ITimeRecordRangeProgress>();

        foreach (var tr in timeRecords)
        {
            var periods = allTimePeriods
                .Where(e => e.RecordId == tr.Id)
                .ToList();

            var minutes = allTimeMinutes
                .Where(e => e.RecordId == tr.Id)
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

    private List<Record> GetTimeRecordsByRange(
        int userId,
        IList<PeriodRecord> allTimePeriods,
        IList<MinuteRecord> allTimeMinutes
    )
    {
        var trIdList = new List<int>();
        trIdList.AddRange(allTimePeriods.Select(e => e.RecordId));
        trIdList.AddRange(allTimeMinutes.Select(e => e.RecordId));
        return recordRepository.FindByIdList(trIdList.Distinct().ToList(), userId) as List<Record>;
    }
}