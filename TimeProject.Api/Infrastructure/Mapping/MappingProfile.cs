using AutoMapper;
using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.Dtos.Codes;
using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Infrastructure.Mapping;

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