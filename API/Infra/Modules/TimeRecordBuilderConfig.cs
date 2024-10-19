using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using API.Core.TimeRecord.Utils;
using API.Modules.TimeRecord.Repositories;
using API.Modules.TimeRecord.UseCases;
using API.Modules.TimeRecord.Utils;

namespace API.Infra.Modules;

public static class TimeRecordBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();
        builder.Services.AddScoped<ITimeRecordMetaRepository, TimeRecordMetaRepository>();
        builder.Services.AddScoped<ITimeRecordHistoryRepository, TimeRecordHistoryRepository>();
        
        builder.Services.AddScoped<ITimeRecordMapDataUtil, TimeRecordMapDataUtil>();

        builder.Services.AddScoped<IGetTimeRecordHistoryUseCase, GetTimeRecordHistoryUseCase>();
        
        builder.Services.AddScoped<IGetPaginatedTimeRecordUseCase, GetPaginatedTimeRecordUseCase>();
        builder.Services.AddScoped<IGetTimeRecordByCodeUseCase, GetTimeRecordByCodeUseCase>();
        builder.Services.AddScoped<IGetTimeRecordByIdUseCase, GetTimeRecordByIdUseCase>();
        builder.Services.AddScoped<ICreateTimeRecordUseCase, CreateTimeRecordUseCase>();
        builder.Services.AddScoped<IUpdateTimeRecordUseCase, UpdateTimeRecordUseCase>();
        builder.Services.AddScoped<IDeleteTimeRecordUseCase, DeleteTimeRecordUseCase>();
        
        builder.Services.AddScoped<ISyncTrMetaUseCase, SyncTrMetaUseCase>();
    }
}