using Core.Statistic;
using Core.Statistic.UseCases;
using App.Modules.Statistic;
using App.Modules.Statistic.UseCases;

namespace App.Infra.Modules;

public static class StatisticBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IGetDayStatisticUseCase, GetDayStatisticUseCase>();
    }
}