using AutoMapper;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.ObjectValues.Pagination.Categories;
using TimeProject.Infrastructure.ObjectValues.Pagination.Codes;
using TimeProject.Infrastructure.ObjectValues.Pagination.Periods;
using TimeProject.Infrastructure.ObjectValues.Pagination.Records;
using TimeProject.Infrastructure.ObjectValues.Pagination.Sessions;
using TimeProject.Infrastructure.ObjectValues.Pagination.Users;

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