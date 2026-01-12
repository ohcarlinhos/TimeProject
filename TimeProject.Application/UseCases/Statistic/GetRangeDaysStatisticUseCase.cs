using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Statistics;
using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues.Statistics;
using TimeProject.Infrastructure.Utils;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Statistic;

public class GetRangeDaysStatisticUseCase(
    IStatisticRepository statisticRepository,
    IRecordRepository recordRepository,
    IPeriodCutUtil periodCutUtil,
    IRecordMapDataUtil mapDataUtil
)
    : IGetRangeDaysStatisticUseCase
{
    public ICustomResult<IRangeStatistic> Handle(
        int userId,
        DateTime? start = null,
        DateTime? end = null,
        int? recordId = null,
        bool skipRangeProgress = false
    )
    {
        return new CustomResult<IRangeStatistic>().SetData(
            (_handle(userId, start, end, recordId, skipRangeProgress)).Statistic
        );
    }

    public ICustomResult<IRangeStatisticsWithDays> Handle(int userId, DateTime start, DateTime end)
    {
        var daysFromRange = new List<DateTime> { start };
        var daysStatistics = new List<IRangeStatistic>();

        var periods = new List<Period>();
        var minutes = new List<Minute>();
        var sessions = new List<Session>();

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
            periods.AddRange((result.Periods as IList<Period>)!);
            minutes.AddRange((result.Minutes as IList<Minute>)!);
            sessions.AddRange((result.Sessions as IList<Session>)!);
            daysStatistics.Add((RangeStatistic)result.Statistic);
            if (result.Statistic.TotalInMinutes > 0) activeDaysCount++;
        }

        var rangeStatistics = MakeRangeStatisticDatas(
            start,
            end,
            periods,
            minutes,
            sessions,
            new List<Record>(),
            daysCount,
            activeDaysCount
        ).Statistic;

        rangeStatistics.RecordRangeProgress = MakeRangeProgress(
            GetTimeRecordsByRange(userId, periods, minutes),
            periods,
            minutes
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

        var timePeriods = periodCutUtil.Handle(timePeriodsByRange as List<Period>, initDate, endDate);

        var allTimerSessions =
            (statisticRepository.GetTimerSessionsByRange(userId, initDate, endDate,
                timeRecordId) as List<Session>)
            .Select(e =>
            {
                e.PeriodRecords = periodCutUtil.Handle(e.PeriodRecords!, initDate, endDate);
                return e;
            })
            .ToList();

        var timeMinutes = statisticRepository.GetTimeMinutesByRange(userId, initDate, endDate, timeRecordId) as List<Minute>;

        var timeRecords = new List<TimeProject.Infrastructure.Entities.Record>();
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
        IList<Period> allTimePeriods,
        IList<Minute> timeMinutes,
        IList<Session> allTimerSessions,
        IList<Record> timeRecords,
        int daysCount = 0,
        int activeDaysCount = 0
    )
    {
        var isolatedPeriods = allTimePeriods.Where(e => e.TimerSessionId == null).ToList();

        var timerSessions = allTimerSessions.Where(e => e.Type == "timer").ToList();
        var pomodoroSessions = allTimerSessions.Where(e => e.Type == "pomodoro").ToList();
        var breakSessions = allTimerSessions.Where(e => e.Type == "break").ToList();

        var allPeriodsTimeSpan = TimeFormatUtil.TimeSpanFromTimePeriods(allTimePeriods);
        var isolatedPeriodsTimeSpan = TimeFormatUtil.TimeSpanFromTimePeriods(isolatedPeriods);
        var timeMinutesTimeSpan = TimeFormatUtil.TimeSpanFromTimeMinutes(timeMinutes);

        var totalTimeSpan = allPeriodsTimeSpan.Add(timeMinutesTimeSpan);
        var totalManualTimeSpan = isolatedPeriodsTimeSpan.Add(timeMinutesTimeSpan);
        var totalSessionTimeSpan = TimeFormatUtil.TimeSpanFromTimerSessions(allTimerSessions);

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
            Periods = (allTimePeriods as IList<IPeriod>)!,
            Minutes = (timeMinutes as IList<IMinute>)!,
            Sessions = (allTimerSessions as IList<ISession>)!,
            Statistic = new RangeStatistic
            {
                StartDay = start,
                EndDay = end,

                TotalHours = TimeFormatUtil.StringFromTimeSpan(totalTimeSpan),
                ManualHours = TimeFormatUtil.StringFromTimeSpan(totalManualTimeSpan),
                MinuteHours = TimeFormatUtil.StringFromTimeSpan(timeMinutesTimeSpan),
                IsolatedPeriodHours = TimeFormatUtil.StringFromTimePeriods(isolatedPeriods),

                TotalInHours = totalTimeSpan.TotalHours,
                TotalInMinutes = totalTimeSpan.TotalMinutes,

                AverageInHours = hoursAvarege,
                AverageInMinutes = minutesAvarege,
                AverageHours = TimeFormatUtil.StringFromTimeSpan(avarageTimeSpan),

                DaysCount = daysCount,
                ActiveDaysCount = activeDaysCount,

                TimerHours = TimeFormatUtil.StringFromTimerSessions(timerSessions),
                PomodoroHours = TimeFormatUtil.StringFromTimerSessions(pomodoroSessions),
                BreakHours = TimeFormatUtil.StringFromTimerSessions(breakSessions),

                TotalTimeSpan = totalTimeSpan,
                IsolatedPeriodsTimeSpan = isolatedPeriodsTimeSpan,
                MinutesTimeSpan = timeMinutesTimeSpan,
                SessionsTimeSpan = totalSessionTimeSpan,

                TimerCount = timerSessions.Count,
                PomodoroCount = pomodoroSessions.Count,
                BreakCount = breakSessions.Count,
                IsolatedPeriodCount = isolatedPeriods.Count,
                ManualCount = isolatedPeriods.Count + timeMinutes.Count,

                PeriodCount = allTimePeriods.Count,
                SessionCount = allTimerSessions.Count,
                MinuteCount = timeMinutes.Count,

                RecordRangeProgress = rangeProgress
            }
        };
    }

    private IList<IRecordRangeProgress> MakeRangeProgress(
        IList<TimeProject.Infrastructure.Entities.Record> timeRecords,
        IList<Period> allTimePeriods,
        IList<Minute> allTimeMinutes
    )
    {
        var rangeProgressList = new List<IRecordRangeProgress>();

        foreach (var tr in timeRecords)
        {
            var periods = allTimePeriods
                .Where(e => e.RecordId == tr.Id)
                .ToList();

            var minutes = allTimeMinutes
                .Where(e => e.RecordId == tr.Id)
                .ToList();

            var periodsTimeSpan = TimeFormatUtil.TimeSpanFromTimePeriods(periods);
            var minutesTimeSpan = TimeFormatUtil.TimeSpanFromTimeMinutes(minutes);
            var totalHoursTimeSpan = periodsTimeSpan.Add(minutesTimeSpan);

            rangeProgressList.Add(new RecordRangeProgress
            {
                Record = mapDataUtil.Handle(tr),
                TotalHours = TimeFormatUtil.StringFromTimeSpan(totalHoursTimeSpan),
                TotalTimeSpan = totalHoursTimeSpan
            });
        }

        return rangeProgressList.OrderByDescending(i => i.TotalTimeSpan).ToList();
    }

    private List<Record> GetTimeRecordsByRange(
        int userId,
        IList<Period> allTimePeriods,
        IList<Minute> allTimeMinutes
    )
    {
        var trIdList = new List<int>();
        trIdList.AddRange(allTimePeriods.Select(e => e.RecordId));
        trIdList.AddRange(allTimeMinutes.Select(e => e.RecordId));
        return recordRepository.FindByIdList(trIdList.Distinct().ToList(), userId) as List<Record>;
    }
}