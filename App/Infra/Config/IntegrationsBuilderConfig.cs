using App.Infra.Integrations;
using App.Infra.Interfaces;

namespace App.Infra.Config;

public static class IntegrationsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomSmtp, CustomSmtp>();
    }
}