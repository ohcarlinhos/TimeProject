using API.Infra.Mapping;

namespace API.Infra.Config;

public static class MappingBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}