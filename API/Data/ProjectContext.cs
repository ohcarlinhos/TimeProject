using API.Modules.Categoria.Entities;
using API.Modules.RegistroDeTempo.Entities;
using API.Modules.Usuario.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<RegistroDeTempoEntity> RegistrosDeTempo { get; set; }
    public DbSet<PeriodoDeTempoEntity> PeriodosDeTempo { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
}