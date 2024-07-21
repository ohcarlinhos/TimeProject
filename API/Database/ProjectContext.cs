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

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserConfiguration());
        mb.ApplyConfiguration(new TimeRecordConfiguration());
        mb.ApplyConfiguration(new TimePeriodConfiguration());

        mb.ApplyConfiguration(new CategoryConfiguration());
        mb.ApplyConfiguration(new RegisterCodeConfiguration());

        mb.Entity<RegisterCode>().HasData([
            new RegisterCode(),
            new RegisterCode(),
            new RegisterCode(),
            new RegisterCode(),
            new RegisterCode(),
        ]);
    }
}