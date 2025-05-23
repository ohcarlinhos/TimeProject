using Entities;
using Shared.TimeRecord;

namespace Shared.Statistic;

public class TimeRecordRangeProgress
{
    public TimeRecordMap? TimeRecord { get; set; }
    public string TotalHours { get; set; } = "";
    public List<TimePeriodEntity>? TimePeriods { get; set; }
    public List<TimeMinuteEntity>? TimeMinutes { get; set; }
}

public class DayStatistic
{
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }

    public string TotalHours { get; set; } = "";
    public string TotalIsolatedPeriodHours { get; set; } = "";
    public string TotalTimerHours { get; set; } = "";
    public string TotalPomodoroHours { get; set; } = "";
    public string TotalBreakHours { get; set; } = "";
    public string TotalTimeMinutesHours { get; set; } = "";
    public string TotalTimeManual { get; set; } = "";

    public int TimerCount { get; set; }
    public int PomodoroCount { get; set; }
    public int BreakCount { get; set; }

    public int IsolatedPeriodCount { get; set; }
    public int SessionCount { get; set; }
    public int TimePeriodCount { get; set; }
    public int TimeMinuteCount { get; set; }
    public int ManualCount { get; set; }
    public int InterruptionCount { get; set; }

    public List<TimeRecordRangeProgress>? TimeRecordRangeProgress { get; set; }

    public int CreatedTimeRecordCount { get; set; }
    public int UpdatedTimeRecordCount { get; set; }
}