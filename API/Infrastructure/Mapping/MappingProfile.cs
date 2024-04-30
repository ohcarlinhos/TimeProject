using API.Modules.Periodo.DTO;
using API.Modules.Periodo.Entities;
using API.Modules.Registro.DTO;
using API.Modules.Registro.Entities;
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