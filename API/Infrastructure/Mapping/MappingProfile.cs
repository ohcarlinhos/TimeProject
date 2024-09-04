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
        CreateMap<User, UserMap>();
        CreateMap<TimeRecord, TimeRecordMap>();
        CreateMap<TimePeriod, TimePeriodMap>();
        CreateMap<Category, CategoryMap>();
        CreateMap<DatedTimePeriod, DatedTimePeriodMap>();
        CreateMap<TimerSession, TimerSessionMap>();
    }
}