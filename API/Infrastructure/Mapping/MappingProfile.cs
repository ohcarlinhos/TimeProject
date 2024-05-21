using API.Modules.Category.DTO;
using API.Modules.Category.Entities;
using API.Modules.TimePeriod.DTO;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimeRecord.DTO;
using API.Modules.TimeRecord.Entities;
using API.Modules.User.DTO;
using API.Modules.User.Entities;
using AutoMapper;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<TimeRecord, TimeRecordDto>();
        CreateMap<TimePeriod, TimePeriodDto>();
        CreateMap<CategoryEntity, CategoryDto>();
    }
}