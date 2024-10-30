using App.Infra.Interfaces;
using App.Infra.Services;

namespace App.Infra.Modules;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}