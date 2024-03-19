using PomodoroAPI.Modules.Auth.Services;
using PomodoroAPI.Modules.Categoria.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Services;
using PomodoroAPI.Modules.Usuario.Services;

namespace PomodoroAPI.Infrastructure.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
        builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
        builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
        builder.Services.AddScoped<IRegistroDeTempoServices, RegistroDeTempoServices>();
        builder.Services.AddScoped<IPeriodoDeTempoServices, PeriodoDeTempoServices>();
    }
}