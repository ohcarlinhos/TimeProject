using AutoMapper;
using Entities;
using Shared.Category;
using Shared.TimePeriod;
using Shared.TimeRecord;
using Shared.User;

namespace API.Infra.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserMap>();
        CreateMap<TimeRecordEntity, TimeRecordMap>();
        CreateMap<TimePeriodEntity, TimePeriodMap>();
        CreateMap<CategoryEntity, CategoryMap>();
        CreateMap<HistoryDay, HistoryDayMap>();
        CreateMap<TimerSessionEntity, TimerSessionMap>();
    }
}