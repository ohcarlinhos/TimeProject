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
    public DbSet<RegisterCodeEntity> RegisterCodes { get; set; }
    public DbSet<TimeRecordMetaEntity> TimeRecordMetas { get; set; }
    public DbSet<TimerSessionEntity> TimerSessions { get; set; }
    public DbSet<ConfirmCodeEntity> ConfirmCodes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserEntityConfiguration());
        mb.ApplyConfiguration(new TimeRecordEntityConfiguration());
        mb.ApplyConfiguration(new TimePeriodEntityConfiguration());
        mb.ApplyConfiguration(new CategoryEntityConfiguration());
        mb.ApplyConfiguration(new RegisterCodeEntityConfiguration());
        mb.ApplyConfiguration(new TimeRecordMetaEntityConfiguration());
        mb.ApplyConfiguration(new TimerSessionEntityConfiguration());
        mb.ApplyConfiguration(new ConfirmCodeEntityConfiguration());

        mb.Entity<RegisterCodeEntity>().HasData([
            new RegisterCodeEntity { Id = "07577660-b921-4e07-bb68-990e8f286475" },
            new RegisterCodeEntity { Id = "209a8b3f-9a5c-4019-b673-846c1b3d92f0" },
            new RegisterCodeEntity { Id = "2b9134e6-4a21-417a-a08c-8600d05247fe" },
            new RegisterCodeEntity { Id = "6daea389-c618-4f44-8958-d423952a4941" },
            new RegisterCodeEntity { Id = "d62a3d33-18c9-4ab3-85ec-c8f22187f078" },
        ]);
    }
}