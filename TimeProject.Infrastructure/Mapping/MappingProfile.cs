using AutoMapper;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Category;
using TimeProject.Infrastructure.ObjectValues.Code;
using TimeProject.Infrastructure.ObjectValues.PeriodRecord;
using TimeProject.Infrastructure.ObjectValues.Record;
using TimeProject.Infrastructure.ObjectValues.RecordSession;

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