using API.Modules.Category.DTO;
using API.Modules.TimePeriod.Map;
using API.Modules.TimeRecord.DTO;
using API.Modules.User.Map;
using AutoMapper;
using Entities;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserMap>();
        CreateMap<TimeRecord, TimeRecordDto>();
        CreateMap<TimePeriod, TimePeriodMap>();
        CreateMap<Category, CategoryDto>();
    }
}