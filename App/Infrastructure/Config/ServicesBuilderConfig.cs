using App.Infrastructure.Interfaces;
using App.Infrastructure.Services;

namespace App.Infrastructure.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}