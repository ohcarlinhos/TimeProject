using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

namespace TimeProject.Infrastructure.ObjectValues.Statistics;

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

    public string MinuteHours { get; set; } = "";

    public TimeSpan TotalTimeSpan { get; set; }
    public TimeSpan MinutesTimeSpan { get; set; }
    public TimeSpan IsolatedPeriodsTimeSpan { get; set; }
    public TimeSpan SessionsTimeSpan { get; set; }

    public int TimerCount { get; set; }
    public int PomodoroCount { get; set; }
    public int BreakCount { get; set; }

    public int IsolatedPeriodCount { get; set; }
    public int SessionCount { get; set; }
    public int PeriodCount { get; set; }
    public int MinuteCount { get; set; }
    public int ManualCount { get; set; }

    public IList<IRecordRangeProgress>? RecordRangeProgress { get; set; }
}