using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Data;

public class ProjetoContext : DbContext
{
    public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<RegistroDeTempoModel> RegistrosDeTempo { get; set; }
    public DbSet<PeriodoDeTempo> PeriodosDeTempo { get; set; }
    public DbSet<CategoriaModel> Categorias { get; set; }
}