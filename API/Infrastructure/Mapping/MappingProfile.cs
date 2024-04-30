using API.Modules.Periodo.DTO;
using API.Modules.Periodo.Entities;
using API.Modules.Registro.DTO;
using API.Modules.Registro.Entities;
using API.Modules.User.DTO;
using API.Modules.User.Entities;
using AutoMapper;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserDto>();
        CreateMap<RegistroEntity, RegistroDto>();
        CreateMap<PeriodoEntity, PeriodoDto>();
    }
}