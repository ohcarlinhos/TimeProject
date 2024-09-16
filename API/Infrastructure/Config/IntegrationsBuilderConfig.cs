using API.Integrations.Smtp;

namespace API.Infrastructure.Config;

public static class IntegrationsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomSmtp, CustomSmtp>();
    }
}