using App.Infra.Settings;
using Microsoft.Extensions.Options;

namespace App.Infra.Config;

public static class SettingsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
        builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<SmtpSettings>>().Value);
    }
}