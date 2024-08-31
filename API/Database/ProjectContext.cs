using API.Database.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Database;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TimeRecord> TimeRecords { get; set; }
    public DbSet<TimePeriod> TimePeriods { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RegisterCode> RegisterCodes { get; set; }
    public DbSet<TimeRecordMeta> TimeRecordMetas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserConfiguration());
        mb.ApplyConfiguration(new TimeRecordConfiguration());
        mb.ApplyConfiguration(new TimePeriodConfiguration());
        mb.ApplyConfiguration(new CategoryConfiguration());
        mb.ApplyConfiguration(new RegisterCodeConfiguration());
        mb.ApplyConfiguration(new TimeRecordMetaConfiguration());

        mb.Entity<RegisterCode>().HasData([
            new RegisterCode { Id = "07577660-b921-4e07-bb68-990e8f286475" },
            new RegisterCode { Id = "209a8b3f-9a5c-4019-b673-846c1b3d92f0" },
            new RegisterCode { Id = "2b9134e6-4a21-417a-a08c-8600d05247fe" },
            new RegisterCode { Id = "6daea389-c618-4f44-8958-d423952a4941" },
            new RegisterCode { Id = "d62a3d33-18c9-4ab3-85ec-c8f22187f078" },
        ]);
    }
}