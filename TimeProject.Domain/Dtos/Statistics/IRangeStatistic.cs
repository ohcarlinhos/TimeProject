namespace TimeProject.Domain.Dtos.Statistics;

public interface IRangeStatistic
{
    DateTimeOffset StartDay { get; set; }
    DateTimeOffset EndDay { get; set; }
    string TotalHours { get; set; }
    string AverageHours { get; set; }
    string IsolatedPeriodHours { get; set; }
    double TotalInHours { get; set; }
    double TotalInMinutes { get; set; }
    double AverageInHours { get; set; }
    double AverageInMinutes { get; set; }
    int DaysCount { get; set; }
    int ActiveDaysCount { get; set; }
    string TimerHours { get; set; }
    string PomodoroHours { get; set; }
    string BreakHours { get; set; }
    string ManualHours { get; set; }
    string MinuteHours { get; set; }
    TimeSpan TotalTimeSpan { get; set; }
    TimeSpan MinutesTimeSpan { get; set; }
    TimeSpan IsolatedPeriodsTimeSpan { get; set; }
    TimeSpan SessionsTimeSpan { get; set; }
    int TimerCount { get; set; }
    int PomodoroCount { get; set; }
    int BreakCount { get; set; }
    int IsolatedPeriodCount { get; set; }
    int SessionCount { get; set; }
    int PeriodCount { get; set; }
    int MinuteCount { get; set; }
    int ManualCount { get; set; }
    IList<IRecordRangeProgress>? RecordRangeProgress { get; set; }
}