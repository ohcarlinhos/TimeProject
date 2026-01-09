using Microsoft.EntityFrameworkCore;
using TimeProject.Api.Database.Configurations;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Database;

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
    public DbSet<TimeMinuteEntity> TimeMinutes { get; set; }
    public DbSet<OAuthEntity> OAuths { get; set; }
    public DbSet<UserAccessLogEntity> UserAccessLogs { get; set; }

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
        mb.ApplyConfiguration(new TimeMinuteEntityConfiguration());
        mb.ApplyConfiguration(new OAuthEntityConfiguration());
        mb.ApplyConfiguration(new UserAccessLogEntityConfiguration());
    }
}