using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Api.Infrastructure.Config;

public static class DatabaseConfig
{
    public static void AddDatabaseConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjectContext>(options => options
            .UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
        );
    }
}