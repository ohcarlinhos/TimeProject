using API.Core.Category;
using API.Core.Statistic;
using API.Core.TimeRecord.Repositories;
using API.Core.User;
using API.Modules.Category;
using API.Modules.Codes.Repositories;
using API.Modules.Statistic;
using API.Modules.TimeRecord.Repositories;
using API.Modules.User;
using Entities;

namespace API.Infra.Config;

public static class RepositoriesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
    }
}