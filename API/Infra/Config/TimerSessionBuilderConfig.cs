using API.Core.TimePeriod;
using API.Core.TimePeriod.Utils;
using API.Core.TimerSession;
using API.Modules.TimePeriod;
using API.Modules.TimePeriod.Utils;

using API.Modules.TimerSession;

namespace API.Infra.Config;

public static class TimerSessionBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();
    }
}