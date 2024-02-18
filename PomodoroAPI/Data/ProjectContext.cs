using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Usuario.Entities;

namespace PomodoroAPI.Data;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<RegistroDeTempoModel> RegistrosDeTempo { get; set; }
    public DbSet<PeriodoDeTempoModel> PeriodosDeTempo { get; set; }
    public DbSet<CategoriaModel> Categorias { get; set; }
}