namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface IRangeStatistic
{
    DateTime StartDay { get; set; }
    DateTime EndDay { get; set; }
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
    string TimeMinuteHours { get; set; }
    TimeSpan TotalTimeSpan { get; set; }
    TimeSpan TimeMinutesTimeSpan { get; set; }
    TimeSpan IsolatedPeriodsTimeSpan { get; set; }
    TimeSpan SessionsTimeSpan { get; set; }
    int TimerCount { get; set; }
    int PomodoroCount { get; set; }
    int BreakCount { get; set; }
    int IsolatedPeriodCount { get; set; }
    int SessionCount { get; set; }
    int TimePeriodCount { get; set; }
    int TimeMinuteCount { get; set; }
    int ManualCount { get; set; }
    IList<ITimeRecordRangeProgress>? TimeRecordRangeProgress { get; set; }
}