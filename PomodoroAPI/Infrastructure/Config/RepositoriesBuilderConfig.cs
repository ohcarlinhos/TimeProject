using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Infrastructure.Config;

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