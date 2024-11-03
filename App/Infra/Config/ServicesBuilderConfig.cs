using App.Infra.Interfaces;
using App.Infra.Services;

namespace App.Infra.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}