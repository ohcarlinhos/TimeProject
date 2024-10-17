using API.Core.Category;
using API.Core.Statistic;
using API.Modules.Category;
using API.Modules.Codes.Repositories;
using API.Modules.Statistic;

namespace API.Infra.Modules;

public static class RepositoriesConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
    }
}