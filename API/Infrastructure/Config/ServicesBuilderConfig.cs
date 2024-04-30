using API.Modules.Auth.Services;
using API.Modules.Categoria.Services;
using API.Modules.Periodo.Services;
using API.Modules.Registro.Services;
using API.Modules.User.Services;

namespace API.Infrastructure.Config;

public static class ServicesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthServices>();
        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
        builder.Services.AddScoped<IRegistroServices, RegistroServices>();
        builder.Services.AddScoped<IPeriodoServices, PeriodoServices>();
    }
}