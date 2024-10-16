using API.Core.Statistic.Repositories;
using API.Core.TimeRecord.Repositories;
using API.Core.User;
using API.Modules.Category.Repositories;
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
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();
        builder.Services.AddScoped<ITimeRecordMetaRepository, TimeRecordMetaRepository>();
        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
    }
}