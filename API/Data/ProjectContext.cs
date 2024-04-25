using API.Modules.Categoria.Entities;
using API.Modules.Periodo;
using API.Modules.Registro;
using API.Modules.Usuario.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<RegistroEntity> Registros { get; set; }
    public DbSet<PeriodoEntity> Periodos { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
}