namespace PomodoroAPI.Infrastructure.Config;

public class CorsBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder, string customCors)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(customCors, policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
    }
}