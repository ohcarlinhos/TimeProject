using API.Infra.Interfaces;
using API.Infra.Services;

namespace API.Infra.Modules;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}