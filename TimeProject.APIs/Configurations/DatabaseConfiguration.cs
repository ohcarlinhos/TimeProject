using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database;

namespace TimeProject.APIs.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<CustomDbContext>(options => options
                .UseNpgsql(
                    configuration.GetConnectionString("PostgresConnection")
                    // b => b.MigrationsAssembly("TimeProject.APIs")
                )
            );
        return services;
    }
}