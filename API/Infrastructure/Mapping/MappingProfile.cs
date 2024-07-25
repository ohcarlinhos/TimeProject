using API.Modules.Category.DTO;
using API.Modules.TimePeriod.DTO;
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
        CreateMap<TimePeriod, TimePeriodDto>();
        CreateMap<Category, CategoryDto>();
    }
}