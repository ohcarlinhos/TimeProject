using Entities;

namespace Shared.Statistic;

public class DayStatistic
{
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
    
    public string TotalHours { get; set; } = "";
    public string TotalIsolatedPeriodHours { get; set; } = "";
    public string TotalTimerHours { get; set; } = "";
    public string TotalPomodoroHours { get; set; } = "";
    public string TotalBreakHours { get; set; } = "";

    public int TimerCount { get; set; }
    public int PomodoroCount { get; set; }
    public int BreakCount { get; set; }
    
    public int IsolatedPeriodCount { get; set; }
    public int SessionCount { get; set; }
    public int TimePeriodCount { get; set; }
    public int InterruptionCount { get; set; }
    
    public int CreatedTimeRecordCount { get; set; }
    public int UpdatedTimeRecordCount { get; set; }
}