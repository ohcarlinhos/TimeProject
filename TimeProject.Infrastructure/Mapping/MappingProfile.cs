using AutoMapper;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.Dtos.Codes;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserOutDto>();
        CreateMap<TimeRecordEntity, TimeRecordOutDto>();
        CreateMap<TimePeriodEntity, TimePeriodOutDto>();
        CreateMap<CategoryEntity, CategoryOutDto>();
        CreateMap<TimeRecordHistoryDay, TimeRecordHistoryDayOutDto>();
        CreateMap<TimerSessionEntity, TimerSessionOutDto>();
        CreateMap<ConfirmCodeEntity, ConfirmCodeOutDto>();
    }
}