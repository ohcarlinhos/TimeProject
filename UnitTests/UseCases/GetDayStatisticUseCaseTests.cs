using API.Core.Statistic;
using API.Modules.Statistic.UseCases;
using API.Modules.TimePeriod.Utils;
using Entities;
using FluentAssertions;
using Moq;
using Shared.Statistic;

namespace UnitTests.UseCases;

public class GetDayStatisticUseCaseTests
{
    private readonly Mock<IStatisticRepository> _staticRepository = new();

    private void SetupStaticRepository(int userId, DateTime today)
    {
        const int timeRecordId = 1;

        var timePeriods = CreateTimePeriodList(today, userId, timeRecordId);
        var timerSessions = CreateTimerSessionList(today, userId, timeRecordId);

        foreach (var session in timerSessions)
        {
            if (session.TimePeriods == null || !session.TimePeriods.Any()) continue;
            timePeriods.AddRange(session.TimePeriods);
        }

        _staticRepository
            .Setup(v => v
                .GetTimePeriodsByRange(userId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(Task.FromResult(timePeriods));

        _staticRepository
            .Setup(v => v.GetTimerSessionsByRange(userId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(Task.FromResult(timerSessions));
    }

    private static List<TimePeriodEntity> CreateTimePeriodList(DateTime today, int userId, int timeRecordId)
    {
        return
        [
            // will be removed
            new TimePeriodEntity
            {
                Start = today.AddHours(-3),
                End = today.AddHours(-3).AddMinutes(15),
                UserId = userId,
                TimerSessionId = null,
                TimeRecordId = timeRecordId
            },
            new TimePeriodEntity
            {
                Start = today,
                End = today.AddMinutes(15).AddSeconds(10),
                UserId = userId,
                TimerSessionId = null,
                TimeRecordId = timeRecordId
            },
            new TimePeriodEntity
            {
                Start = today.AddMinutes(20),
                End = today.AddMinutes(45),
                UserId = userId,
                TimerSessionId = null,
                TimeRecordId = timeRecordId
            },
            // will be removed
            new TimePeriodEntity
            {
                Start = today.AddDays(1).AddMinutes(20),
                End = today.AddDays(1).AddMinutes(45),
                UserId = userId,
                TimerSessionId = null,
                TimeRecordId = timeRecordId
            }
        ];
    }

    private static List<TimerSessionEntity> CreateTimerSessionList(DateTime today, int userId, int timeRecordId)
    {
        return
        [
            new TimerSessionEntity
            {
                Id = 1,
                UserId = userId,
                TimeRecordId = timeRecordId,
                Type = "timer",
                TimePeriods = new List<TimePeriodEntity>
                {
                    new()
                    {
                        Start = today.AddHours(3), End = today.AddHours(4).AddMinutes(15),
                        TimerSessionId = 1
                    },
                    new()
                    {
                        Start = today.AddHours(4).AddMinutes(20), End = today.AddHours(4).AddMinutes(40),
                        TimerSessionId = 1
                    },
                },
            },
            new TimerSessionEntity
            {
                Id = 2,
                UserId = userId,
                TimeRecordId = timeRecordId,
                Type = "pomodoro",
                TimePeriods = new List<TimePeriodEntity>
                {
                    new()
                    {
                        Start = today.AddHours(5), End = today.AddHours(5).AddMinutes(10),
                        TimerSessionId = 2,
                    },
                    new()
                    {
                        Start = today.AddHours(5).AddMinutes(15), End = today.AddHours(5).AddMinutes(30),
                        TimerSessionId = 2,
                    }
                },
            },
            new TimerSessionEntity
            {
                Id = 3,
                UserId = userId,
                TimeRecordId = timeRecordId,
                Type = "break",
                TimePeriods = new List<TimePeriodEntity>
                {
                    new()
                    {
                        Start = today.AddHours(6), End = today.AddHours(6).AddMinutes(15).AddSeconds(5),
                        TimerSessionId = 3
                    }
                },
            },
            new TimerSessionEntity
            {
                Id = 4,
                UserId = userId,
                TimeRecordId = timeRecordId,
                Type = "timer",
                TimePeriods = new List<TimePeriodEntity>()
            }
        ];
    }

    private static void RunAssets(DayStatistic? data)
    {
        data.Should().NotBeNull();

        data!.TimePeriodCount.Should().Be(7);
        data.SessionCount.Should().Be(4);

        data.IsolatedPeriodCount.Should().Be(2);
        data.TimerCount.Should().Be(2);
        data.PomodoroCount.Should().Be(1);
        data.BreakCount.Should().Be(1);

        data.TotalHours.Should().Be("2h 55m 15s");

        data.TotalIsolatedPeriodHours.Should().Be("40m 10s");
        data.TotalTimerHours.Should().Be("1h 35m");
        data.TotalPomodoroHours.Should().Be("25m");
        data.TotalBreakHours.Should().Be("15m 5s");
    }

    [Fact]
    public async void Given_Date_When_IsToday_Then_ShouldReturnDayStatistic()
    {
        // Arrange
        var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, new TimePeriodCutUtil());

        const int userId = 1;
        var today = DateTime.Today;

        SetupStaticRepository(userId, today);

        // Act
        var data = (await getDayStatistics.Handle(userId, today)).Data;

        // Assert
        RunAssets(data);
    }

    [Fact]
    public async void Given_Date_When_DontProvide_Then_ShouldReturnDayStatistic()
    {
        // Arrange
        var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, new TimePeriodCutUtil());

        const int userId = 1;
        var today = DateTime.Today;

        SetupStaticRepository(userId, today);

        // Act
        var data = (await getDayStatistics.Handle(userId)).Data;

        // Assert
        RunAssets(data);
    }

    [Fact]
    public async void Given_Date_When_BrazilUtc_Then_ShouldReturnDayStatistic()
    {
        // Arrange
        var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, new TimePeriodCutUtil());

        const int userId = 1;
        const int addHoursOnInitDate = 3;
        var today = DateTime.Today.AddHours(addHoursOnInitDate);

        SetupStaticRepository(userId, today);

        // Act
        var data = (await getDayStatistics.Handle(userId, today, addHoursOnInitDate)).Data;

        // Assert
        RunAssets(data);
    }
}