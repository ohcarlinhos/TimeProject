using API.Core.TimePeriod;
using API.Core.TimePeriod.Utils;
using API.Core.TimerSession;
using API.Modules.TimePeriod;
using API.Modules.TimePeriod.Utils;
using API.Modules.TimerSession;

namespace API.Infra.Modules;

public static class TimePeriodConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();

        builder.Services.AddScoped<ITimePeriodServices, TimePeriodServices>();

        builder.Services.AddScoped<ITimePeriodMapDataUtil, TimePeriodMapDataUtil>();
        builder.Services.AddScoped<ITimePeriodCutUtil, TimePeriodCutUtil>();
    }
}