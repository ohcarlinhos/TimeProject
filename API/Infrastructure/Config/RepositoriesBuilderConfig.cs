using API.Modules.Categoria.Repositories;
using API.Modules.RegistroDeTempo.Repositories;
using API.Modules.Usuario.Repositories;

namespace API.Infrastructure.Config;

public static class RepositoriesBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddScoped<IRegistroDeTempoRepository, RegistroDeTempoRepository>();
        builder.Services.AddScoped<IPeriodoDeTempoRepository, PeriodoDeTempoRepository>();
    }
}