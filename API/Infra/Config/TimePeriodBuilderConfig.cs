using API.Core.TimePeriod.Repositories;
using API.Core.TimePeriod.Services;
using API.Core.TimePeriod.Util;
using API.Core.TimeRecord.UseCases;
using API.Core.TimerSession;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimePeriod.Services;
using API.Modules.TimePeriod.Util;
using API.Modules.TimeRecord.UseCases;
using API.Modules.TimerSession;

namespace API.Infra.Config;

public static class TimePeriodBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimePeriodServices, TimePeriodServices>();

        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();
        builder.Services.AddScoped<ITimePeriodHistoryRepository, TimePeriodHistoryRepository>();

        builder.Services.AddScoped<IGetTimeRecordHistoryUseCase, GetTimeRecordHistoryUseCase>();
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();

        builder.Services.AddScoped<ITimePeriodMapDataUtil, TimePeriodMapDataUtil>();
        builder.Services.AddScoped<ITimePeriodCutUtil, TimePeriodCutUtil>();
    }
}