namespace App.Infrastructure.Config;

public static class CorsConfig
{
    public static void AddCorsConfig(this WebApplicationBuilder builder, string customCors)
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