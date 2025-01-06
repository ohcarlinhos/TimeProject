using App.Infrastructure.Handlers;
using App.Infrastructure.Interfaces;

namespace App.Infrastructure.Config;

public static class HandlersBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailHandler, EmailHandler>();
    }
}