using App.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Config;

public static class DatabaseBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjectContext>(
            options => options
                .UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
        );
    }
}