using API.Modules.Codes.Repositories;
using API.Modules.Codes.Services;

namespace API.Infra.Modules;

public static class CodeConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
        builder.Services.AddScoped<IConfirmCodeServices, ConfirmCodeServices>();
    }
}