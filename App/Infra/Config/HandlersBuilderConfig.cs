using App.Infra.Handlers;
using App.Infra.Interfaces;

namespace App.Infra.Config;

public static class HandlersBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailHandler, EmailHandler>();
        builder.Services.AddScoped<IHookHandler, HookHandler>();    
    }
}