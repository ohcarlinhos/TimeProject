using Core.TimerSession;
using Core.TimerSession.UseCases;
using App.Modules.TimerSession;
using App.Modules.TimerSession.UseCases;

namespace App.Infrastructure.Modules;

public static class TimerSessionBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();
        builder.Services.AddScoped<IDeleteTimerSessionUseCase, DeleteTimerSessionUseCase>();
    }
}