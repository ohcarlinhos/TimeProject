using API.Core.Statistic.UseCases;
using API.Core.TimePeriod;
using API.Core.TimeRecord.Services;
using API.Core.TimeRecord.UseCases;
using API.Core.User;
using API.Infra.Services;
using API.Modules.Auth.Services;
using API.Modules.Category.Services;
using API.Modules.Codes.Services;
using API.Modules.Statistic.UseCases;
using API.Modules.TimePeriod;
using API.Modules.TimeRecord.Services;
using API.Modules.TimeRecord.UseCases;
using API.Modules.User.Services;

namespace API.Infra.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<ICategoryServices, CategoryServices>();
        builder.Services.AddScoped<ITimeRecordServices, TimeRecordServices>();
        builder.Services.AddScoped<ITimePeriodServices, TimePeriodServices>();
        builder.Services.AddScoped<ITimeRecordMetaServices, TimeRecordMetaServices>();
        builder.Services.AddScoped<IConfirmCodeServices, ConfirmCodeServices>();

        // Use Cases
        // Time Record
        builder.Services.AddScoped<IFindTimeRecordById, FindTimeRecordById>();

        // Statistics
        builder.Services.AddScoped<IGetDayStatisticsUseCase, GetDayStatisticsUseCase>();

        // Token
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}