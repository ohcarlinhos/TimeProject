using API.Modules.Core.Handlers.Email;

namespace API.Infra.Config;

public static class HandlersBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailHandler, EmailHandler>();
    }
}