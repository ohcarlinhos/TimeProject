using API.Core.Codes;
using API.Modules.Codes;

namespace API.Infra.Modules;

public static class CodeConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
        builder.Services.AddScoped<IConfirmCodeServices, ConfirmCodeServices>();
    }
}