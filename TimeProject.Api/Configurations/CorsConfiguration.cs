namespace TimeProject.Api.Configurations;

public static class CorsConfiguration
{
    public static void AddCorsConfiguration(this WebApplicationBuilder builder, string customCors)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(customCors, policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });
    }
}