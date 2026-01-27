using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database;

namespace TimeProject.APIs.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<CustomDbContext>(options => options
                .UseNpgsql(
                    builder.Configuration.GetConnectionString("PostgresConnection")
                    // b => b.MigrationsAssembly("TimeProject.APIs")
                )
            );
    }
}