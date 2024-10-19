using API.Core.Auth;
using API.Modules.Auth;

namespace API.Infra.Modules;

public static class AuthConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
    }
}