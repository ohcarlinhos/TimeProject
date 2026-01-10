using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Api.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjectContext>(options => options
            .UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
        );
    }
}