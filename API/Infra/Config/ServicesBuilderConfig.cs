using API.Infra.Services;
using API.Modules.Auth.Services;
using API.Modules.Category.Services;
using API.Modules.Codes.Services;
using API.Modules.TimePeriod.Services;
using API.Modules.TimeRecord.Services;
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
        builder.Services.AddScoped<ITimerSessionServices, TimerSessionServices>();
        builder.Services.AddScoped<IConfirmCodeServices, ConfirmCodeServices>();

        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}