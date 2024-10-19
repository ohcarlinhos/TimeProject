using API.Core.Statistic;
using API.Core.Statistic.UseCases;
using API.Modules.Statistic;
using API.Modules.Statistic.UseCases;

namespace API.Infra.Modules;

public static class StatisticBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IGetDayStatisticUseCase, GetDayStatisticUseCase>();
    }
}