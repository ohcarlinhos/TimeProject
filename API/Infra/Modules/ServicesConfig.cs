using API.Core.Auth;
using API.Core.Category;
using API.Core.Statistic.UseCases;
using API.Core.TimePeriod;
using API.Infra.Interfaces;
using API.Infra.Services;
using API.Modules.Auth;
using API.Modules.Category;
using API.Modules.Codes.Services;
using API.Modules.Statistic.UseCases;
using API.Modules.TimePeriod;

namespace API.Infra.Modules;

public static class ServicesConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
        builder.Services.AddScoped<ICategoryServices, CategoryServices>();
        builder.Services.AddScoped<ITimePeriodServices, TimePeriodServices>();

        builder.Services.AddScoped<IConfirmCodeServices, ConfirmCodeServices>();
        
        builder.Services.AddScoped<IGetDayStatisticsUseCase, GetDayStatisticsUseCase>();

        // Token
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}