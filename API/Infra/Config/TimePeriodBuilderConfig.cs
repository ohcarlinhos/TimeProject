using API.Core.TimePeriod.Repositories;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimePeriod.Services;
using API.Modules.TimePeriod.UseCases;
using API.Modules.TimePeriod.Util;

namespace API.Infra.Config;

public static class TimePeriodBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimePeriodServices, TimePeriodServices>();

        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();
        builder.Services.AddScoped<ITimePeriodHistoryRepository, TimePeriodHistoryRepository>();

        builder.Services.AddScoped<IGetTimePeriodHistory, GetTimePeriodHistory>();
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();

        builder.Services.AddScoped<ITimePeriodMapDataUtil, TimePeriodMapDataUtil>();
        builder.Services.AddScoped<ITimePeriodCutUtil, TimePeriodCutUtil>();
    }
}