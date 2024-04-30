using API.Modules.Categoria.Repositories;
using API.Modules.Periodo.Repositories;
using API.Modules.Registro.Repositories;
using API.Modules.User.Repositories;

namespace API.Infrastructure.Config;

public static class RepositoriesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
        builder.Services.AddScoped<IPeriodoRepository, PeriodoRepository>();
    }
}