using Core.TimerSession;
using Core.TimerSession.UseCases;
using API.Modules.TimerSession;
using API.Modules.TimerSession.UseCases;

namespace API.Infra.Modules;

public static class TimerSessionBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();
        builder.Services.AddScoped<IDeleteTimerSessionUseCase, DeleteTimerSessionUseCase>();
    }
}