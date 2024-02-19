using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.Usuario.Entities;

namespace PomodoroAPI.Data;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<RegistroDeTempoEntity> RegistrosDeTempo { get; set; }
    public DbSet<PeriodoDeTempoEntity> PeriodosDeTempo { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
}