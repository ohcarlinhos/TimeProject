using API.Modules.Category.Repositories;
using API.Modules.Codes.Repositories;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimeRecord.Repositories;
using API.Modules.User.Repositories;
using Entities;

namespace API.Infrastructure.Config;

public static class RepositoriesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();
        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();
        builder.Services.AddScoped<ITimeRecordMetaRepository, TimeRecordMetaRepository>();
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();
    }
}