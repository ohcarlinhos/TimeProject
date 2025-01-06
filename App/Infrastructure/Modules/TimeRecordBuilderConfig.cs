using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Core.TimeRecord.Utils;
using App.Modules.TimeRecord.Repositories;
using App.Modules.TimeRecord.UseCases;
using App.Modules.TimeRecord.Utils;

namespace App.Infrastructure.Modules;

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
        builder.Services.AddScoped<ISearchTimeRecordUseCase, SearchTimeRecordUseCase>();
        
        builder.Services.AddScoped<ISyncTrMetaUseCase, SyncTrMetaUseCase>();
        builder.Services.AddScoped<ISyncAllTrMetaUseCase, SyncAllTrMetaUseCase>();
    }
}