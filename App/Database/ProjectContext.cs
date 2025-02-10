using App.Database.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Database;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TimeRecordEntity> TimeRecords { get; set; }
    public DbSet<TimePeriodEntity> TimePeriods { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TimeRecordMetaEntity> TimeRecordMetas { get; set; }
    public DbSet<TimerSessionEntity> TimerSessions { get; set; }
    public DbSet<ConfirmCodeEntity> ConfirmCodes { get; set; }
    public DbSet<UserPasswordEntity> UserPasswords { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserEntityConfiguration());
        mb.ApplyConfiguration(new TimeRecordEntityConfiguration());
        mb.ApplyConfiguration(new TimePeriodEntityConfiguration());
        mb.ApplyConfiguration(new CategoryEntityConfiguration());
        mb.ApplyConfiguration(new TimeRecordMetaEntityConfiguration());
        mb.ApplyConfiguration(new TimerSessionEntityConfiguration());
        mb.ApplyConfiguration(new ConfirmCodeEntityConfiguration());
        mb.ApplyConfiguration(new UserPasswordEntityConfiguration());
    }
}