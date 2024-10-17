using API.Infra.Integrations;
using API.Infra.Interfaces;

namespace API.Infra.Config;

public static class IntegrationsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomSmtp, CustomSmtp>();
    }
}