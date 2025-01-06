using App.Infra.Interfaces;
using App.Infrastructure.Integrations;
using App.Infrastructure.Interfaces;

namespace App.Infrastructure.Config;

public static class IntegrationsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomSmtp, CustomSmtp>();
        builder.Services.AddScoped<ICustomBot, CustomBot>();
    }
}