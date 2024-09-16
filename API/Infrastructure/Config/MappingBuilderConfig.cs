using API.Infrastructure.Mapping;

namespace API.Infrastructure.Config;

public static class MappingBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}