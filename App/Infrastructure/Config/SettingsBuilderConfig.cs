using App.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace App.Infrastructure.Config;

public static class SettingsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
        builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
        
        builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection("Telegram"));
        builder.Services.Configure<TurnstileSettings>(builder.Configuration.GetSection("Turnstile"));
        
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<SmtpSettings>>().Value);
        
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TelegramSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TurnstileSettings>>().Value);
    }
}