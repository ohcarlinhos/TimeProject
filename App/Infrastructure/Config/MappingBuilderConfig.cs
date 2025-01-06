using App.Infrastructure.Mapping;

namespace App.Infrastructure.Config;

public static class MappingBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}