using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.Services;
using API.Core.TimeRecord.UseCases;
using API.Core.TimeRecord.Utils;
using API.Modules.TimeRecord.Repositories;
using API.Modules.TimeRecord.Services;
using API.Modules.TimeRecord.UseCases;
using API.Modules.TimeRecord.Utils;

namespace API.Infra.Config;

public static class TimeRecordBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();
        builder.Services.AddScoped<ITimeRecordMetaRepository, TimeRecordMetaRepository>();
        builder.Services.AddScoped<ITimeRecordHistoryRepository, TimeRecordHistoryRepository>();

        builder.Services.AddScoped<ITimeRecordServices, TimeRecordServices>();
        builder.Services.AddScoped<ITimeRecordMetaServices, TimeRecordMetaServices>();

        builder.Services.AddScoped<ITimeRecordMapDataUtil, TimeRecordMapDataUtil>();

        builder.Services.AddScoped<IGetTimeRecordHistoryUseCase, GetTimeRecordHistoryUseCase>();
        builder.Services.AddScoped<IFindTimeRecordById, FindTimeRecordById>();
    }
}