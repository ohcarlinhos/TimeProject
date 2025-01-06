using AutoMapper;
using Entities;
using Shared.Category;
using Shared.Codes;
using Shared.TimePeriod;
using Shared.TimeRecord;
using Shared.User;

namespace App.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserMap>();
        CreateMap<TimeRecordEntity, TimeRecordMap>();
        CreateMap<TimePeriodEntity, TimePeriodMap>();
        CreateMap<CategoryEntity, CategoryMap>();
        CreateMap<TimeRecordHistoryDay, TimeRecordHistoryDayMap>();
        CreateMap<TimerSessionEntity, TimerSessionMap>();
        CreateMap<ConfirmCodeEntity, ConfirmCodeMap>();
    }
}