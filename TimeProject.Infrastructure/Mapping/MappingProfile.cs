using AutoMapper;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Entities;

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