namespace TimeProject.APIs.Configurations;

public static class CorsConfiguration
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, string customCors)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(customCors, policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        return services;
    }
}