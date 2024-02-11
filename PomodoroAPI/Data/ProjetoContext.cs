using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Models;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Data;

public class ProjetoContext : DbContext
{
    public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TempoFocado> TemposFocado { get; set; }
    public DbSet<EventoDeFoco> EventosDeFoco { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}