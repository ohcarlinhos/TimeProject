using AutoMapper;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserOutDto>();
        CreateMap<Record, TimeRecordOutDto>();
        CreateMap<PeriodRecord, TimePeriodOutDto>();
        CreateMap<Category, CategoryOutDto>();
        CreateMap<TimeRecordHistoryDay, TimeRecordHistoryDayOutDto>();
        CreateMap<RecordSession, TimerSessionOutDto>();
        CreateMap<ConfirmCode, ConfirmCodeOutDto>();
    }
}