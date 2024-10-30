using Core.TimePeriod;
using Core.TimePeriod.UseCases;
using Core.TimePeriod.Utils;
using API.Modules.TimePeriod;
using API.Modules.TimePeriod.UseCases;
using API.Modules.TimePeriod.Utils;

namespace API.Infra.Modules;

public static class TimePeriodBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();
        
        builder.Services.AddScoped<ITimePeriodMapDataUtil, TimePeriodMapDataUtil>();
        builder.Services.AddScoped<ITimePeriodCutUtil, TimePeriodCutUtil>();
        builder.Services.AddScoped<ITimePeriodValidateUtil, TimePeriodValidateUtil>();

        builder.Services.AddScoped<IGetPaginatedTimePeriodUseCase, GetPaginatedTimePeriodUseCase>();
        builder.Services.AddScoped<ICreateTimePeriodByListUseCase, CreateTimePeriodByListUseCase>();
        builder.Services.AddScoped<ICreateTimePeriodUseCase, CreateTimePeriodUseCase>();
        builder.Services.AddScoped<IUpdateTimePeriodUseCase, UpdateTimePeriodUseCase>();
        builder.Services.AddScoped<IDeleteTimePeriodUseCase, DeleteTimePeriodUseCase>();
    }
}