using API.Infra.Handlers.Email;
using API.Infra.Interfaces;

namespace API.Infra.Config;

public static class HandlersBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailHandler, EmailHandler>();
    }
}