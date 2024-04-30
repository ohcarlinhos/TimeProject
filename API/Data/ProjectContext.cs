using Microsoft.EntityFrameworkCore;
using API.Modules.Categoria.Entities;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimeRecord.Entities;
using API.Modules.User.Entities;

namespace API.Data;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TimeRecordEntity> TimeRecords { get; set; }
    public DbSet<TimePeriodEntity> TimePeriods { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
}