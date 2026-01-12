using AutoMapper;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues.Category;
using TimeProject.Infrastructure.ObjectValues.Code;
using TimeProject.Infrastructure.ObjectValues.Period;
using TimeProject.Infrastructure.ObjectValues.Record;
using TimeProject.Infrastructure.ObjectValues.RecordSession;
using TimeProject.Infrastructure.ObjectValues.User;

namespace TimeProject.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserOutDto>();
        CreateMap<Record, RecordOutDto>();
        CreateMap<Period, PeriodOutDto>();
        CreateMap<Category, CategoryOutDto>();
        CreateMap<RecordHistoryDay, RecordHistoryDayOutDto>();
        CreateMap<Session, SessionOutDto>();
        CreateMap<ConfirmCode, ConfirmCodeOutDto>();
    }
}