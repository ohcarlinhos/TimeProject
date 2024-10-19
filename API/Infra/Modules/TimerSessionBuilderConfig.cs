using API.Core.TimerSession;
using API.Modules.TimerSession;

namespace API.Infra.Modules;

public static class TimerSessionBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();
    }
}