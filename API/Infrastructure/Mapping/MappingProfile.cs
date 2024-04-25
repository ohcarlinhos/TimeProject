using API.Modules.Periodo;
using API.Modules.Registro;
using API.Modules.Usuario.DTO;
using API.Modules.Usuario.Entities;
using AutoMapper;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioEntity, UsuarioDTO>();
        CreateMap<RegistroEntity, RegistroDto>();
        CreateMap<PeriodoEntity, PeriodoDto>();
    }
}