using API.Modules.Auth.Services;
using API.Modules.Categoria.Services;
using API.Modules.Periodo;
using API.Modules.Periodo.Interfaces;
using API.Modules.Registro;
using API.Modules.Registro.Interfaces;
using API.Modules.Usuario.Services;

namespace API.Infrastructure.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
        builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
        builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
        builder.Services.AddScoped<IRegistroServices, RegistroServices>();
        builder.Services.AddScoped<IPeriodoServices, PeriodoServices>();
    }
}