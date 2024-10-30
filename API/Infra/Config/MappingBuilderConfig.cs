using App.Infra.Mapping;

namespace App.Infra.Config;

public static class MappingBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}