using API.Modules.Category.Map;
using API.Modules.TimePeriod.Map;
using API.Modules.TimeRecord.Map;
using API.Modules.User.Map;
using AutoMapper;
using Entities;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserMap>();
        CreateMap<TimeRecord, TimeRecordMap>();
        CreateMap<TimePeriod, TimePeriodMap>();
        CreateMap<Category, CategoryMap>();
    }
}