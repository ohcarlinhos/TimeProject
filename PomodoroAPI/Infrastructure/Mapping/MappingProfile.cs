using AutoMapper;
using PomodoroAPI.Modules.RegistroDeTempo.DTO;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.Usuario.DTO;
using PomodoroAPI.Modules.Usuario.Entities;

namespace PomodoroAPI.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioEntity, UsuarioDTO>();
        CreateMap<RegistroDeTempoEntity, RegistroDeTempoDTO>();
        CreateMap<PeriodoDeTempoEntity, PeriodoDeTempoDTO>();
    }
}