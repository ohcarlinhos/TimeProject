using AutoMapper;
using Entities;
using Shared.Category;
using Shared.TimePeriod;
using Shared.TimeRecord;
using Shared.User;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserMap>();
        CreateMap<TimeRecordEntity, TimeRecordMap>();
        CreateMap<TimePeriodEntity, TimePeriodMap>();
        CreateMap<CategoryEntity, CategoryMap>();
        CreateMap<DatedTime, DatedTimeMap>();
        CreateMap<TimerSessionEntity, TimerSessionMap>();
    }
}