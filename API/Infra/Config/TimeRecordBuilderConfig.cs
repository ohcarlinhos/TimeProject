using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.Util;
using API.Modules.TimeRecord.Repositories;
using API.Modules.TimeRecord.Util;

namespace API.Infra.Config;

public static class TimeRecordBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimeRecordHistoryRepository, TimeRecordHistoryRepository>();
        builder.Services.AddScoped<ITimeRecordMapDataUtil, TimeRecordMapDataUtil>();
    }
}