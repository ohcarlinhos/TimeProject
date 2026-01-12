namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public class RangeStatistic : IRangeStatistic
{
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }

    public string TotalHours { get; set; } = "";
    public string AverageHours { get; set; } = "";
    public string IsolatedPeriodHours { get; set; } = "";

    public double TotalInHours { get; set; } = 0;
    public double TotalInMinutes { get; set; } = 0;
    public double AverageInHours { get; set; } = 0;
    public double AverageInMinutes { get; set; } = 0;

    public int DaysCount { get; set; } = 0;
    public int ActiveDaysCount { get; set; } = 0;

    public string TimerHours { get; set; } = "";
    public string PomodoroHours { get; set; } = "";
    public string BreakHours { get; set; } = "";
    public string ManualHours { get; set; } = "";

    public string TimeMinuteHours { get; set; } = "";

    public TimeSpan TotalTimeSpan { get; set; }
    public TimeSpan TimeMinutesTimeSpan { get; set; }
    public TimeSpan IsolatedPeriodsTimeSpan { get; set; }
    public TimeSpan SessionsTimeSpan { get; set; }

    public int TimerCount { get; set; }
    public int PomodoroCount { get; set; }
    public int BreakCount { get; set; }

    public int IsolatedPeriodCount { get; set; }
    public int SessionCount { get; set; }
    public int TimePeriodCount { get; set; }
    public int TimeMinuteCount { get; set; }
    public int ManualCount { get; set; }

    public IList<ITimeRecordRangeProgress>? TimeRecordRangeProgress { get; set; }
}