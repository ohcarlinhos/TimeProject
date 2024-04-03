using API.Modules.RegistroDeTempo.DTO;
using API.Modules.RegistroDeTempo.Entities;
using API.Modules.Usuario.DTO;
using API.Modules.Usuario.Entities;
using AutoMapper;

namespace API.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioEntity, UsuarioDTO>();
        CreateMap<RegistroDeTempoEntity, RegistroDeTempoDto>();
        CreateMap<PeriodoDeTempoEntity, PeriodoDeTempoDto>();
    }
}