using FluentAssertions;
using Moq;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Dtos.Statistics;
using TimeProject.Domain.Repositories;
using TimeProject.Infrastructure.ObjectValues.Statistics;

namespace TimeProject.UnitTests.UseCases;

public class GetRangeDaysStatisticUseCaseTests
{
    private readonly Mock<IStatisticRepository> _staticRepository = new();

    private void SetupStaticRepository(int userId, DateTime today)
    {
        const int recordId = 1;

        var timePeriods = CreateRecordPeriodList(today, userId, recordId);
        var recordSessions = CreateTimerSessionList(today, userId, recordId);

        foreach (var session in recordSessions)
        {
            if (session.PeriodRecords == null || !session.PeriodRecords.Any()) continue;
            timePeriods.AddRange(session.PeriodRecords);
        }

        _staticRepository
            .Setup(v => v
                .GetTimePeriodsByRange(userId, It.IsAny<DateTime>(), It.IsAny<DateTime>(), null))
            .Returns(timePeriods as IList<IPeriod>);

        _staticRepository
            .Setup(v => v.GetTimerSessionsByRange(userId, It.IsAny<DateTime>(), It.IsAny<DateTime>(), null))
            .Returns(recordSessions as IList<ISession>);
    }

    private static List<Period> CreateRecordPeriodList(DateTime today, int userId, int recordId)
    {
        return
        [
            // will be removed
            new Period
            {
                Start = today.AddHours(-3),
                End = today.AddHours(-3).AddMinutes(15),
                UserId = userId,
                TimerSessionId = null,
                RecordId = recordId
            },
            new Period
            {
                Start = today,
                End = today.AddMinutes(15).AddSeconds(10),
                UserId = userId,
                TimerSessionId = null,
                RecordId = recordId
            },
            new Period
            {
                Start = today.AddMinutes(20),
                End = today.AddMinutes(45),
                UserId = userId,
                TimerSessionId = null,
                RecordId = recordId
            },
            // will be removed
            new Period
            {
                Start = today.AddDays(1).AddMinutes(20),
                End = today.AddDays(1).AddMinutes(45),
                UserId = userId,
                TimerSessionId = null,
                RecordId = recordId
            }
        ];
    }

    private static List<Session> CreateTimerSessionList(DateTime today, int userId, int recordId)
    {
        return
        [
            new Session
            {
                Id = 1,
                UserId = userId,
                RecordId = recordId,
                Type = "timer",
                PeriodRecords = new List<Period>
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
                    }
                }
            },
            new Session
            {
                Id = 2,
                UserId = userId,
                RecordId = recordId,
                Type = "pomodoro",
                PeriodRecords = new List<Period>
                {
                    new()
                    {
                        Start = today.AddHours(5), End = today.AddHours(5).AddMinutes(10),
                        TimerSessionId = 2
                    },
                    new()
                    {
                        Start = today.AddHours(5).AddMinutes(15), End = today.AddHours(5).AddMinutes(30),
                        TimerSessionId = 2
                    }
                }
            },
            new Session
            {
                Id = 3,
                UserId = userId,
                RecordId = recordId,
                Type = "break",
                PeriodRecords = new List<Period>
                {
                    new()
                    {
                        Start = today.AddHours(6), End = today.AddHours(6).AddMinutes(15).AddSeconds(5),
                        TimerSessionId = 3
                    }
                }
            },
            new Session
            {
                Id = 4,
                UserId = userId,
                RecordId = recordId,
                Type = "timer",
                PeriodRecords = new List<Period>()
            }
        ];
    }

    private static void RunAssets(RangeStatistic? data)
    {
        data.Should().NotBeNull();

        data!.PeriodCount.Should().Be(7);
        data.SessionCount.Should().Be(4);

        data.IsolatedPeriodCount.Should().Be(2);
        data.TimerCount.Should().Be(2);
        data.PomodoroCount.Should().Be(1);
        data.BreakCount.Should().Be(1);

        data.TotalHours.Should().Be("2h 55m 15s");

        data.IsolatedPeriodHours.Should().Be("40m 10s");
        data.TimerHours.Should().Be("1h 35m");
        data.PomodoroHours.Should().Be("25m");
        data.BreakHours.Should().Be("15m 5s");
    }

    // [Fact]
    // public async void Given_Date_When_IsToday_Then_ShouldReturnDayStatistic()
    // {
    //     // Arrange
    //     var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, _recordRepository.Object,
    //         new PeriodCutUtil(), new RecordMapDataUtil());
    //
    //     const int userId = 1;
    //     var today = DateTime.Today;
    //
    //     SetupStaticRepository(userId, today);
    //
    //     // Act
    //     var data = (await getDayStatistics.Handle(userId, today)).Data;
    //
    //     // Assert
    //     RunAssets(data);
    // }

    // [Fact]
    // public async void Given_Date_When_DontProvide_Then_ShouldReturnDayStatistic()
    // {
    //     // Arrange
    //     var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, new TimePeriodCutUtil());
    //
    //     const int userId = 1;
    //     var today = DateTime.Today;
    //
    //     SetupStaticRepository(userId, today);
    //
    //     // Act
    //     var data = (await getDayStatistics.Handle(userId)).Data;
    //
    //     // Assert
    //     RunAssets(data);
    // }
    //
    // [Fact]
    // public async void Given_Date_When_BrazilUtc_Then_ShouldReturnDayStatistic()
    // {
    //     // Arrange
    //     var getDayStatistics = new GetDayStatisticUseCase(_staticRepository.Object, new TimePeriodCutUtil());
    //
    //     const int userId = 1;
    //     const int addHoursOnInitDate = 3;
    //     var today = DateTime.Today.AddHours(addHoursOnInitDate);
    //
    //     SetupStaticRepository(userId, today);
    //
    //     // Act
    //     var data = (await getDayStatistics.Handle(userId, today, addHoursOnInitDate)).Data;
    //
    //     // Assert
    //     RunAssets(data);
    // }
}