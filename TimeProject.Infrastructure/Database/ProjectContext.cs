using Microsoft.EntityFrameworkCore;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Configurations;

namespace TimeProject.Infrastructure.Database;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Record> TimeRecords { get; set; }
    public DbSet<PeriodRecord> TimePeriods { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RecordMeta> TimeRecordMetas { get; set; }
    public DbSet<TimerSession> TimerSessions { get; set; }
    public DbSet<ConfirmCode> ConfirmCodes { get; set; }
    public DbSet<UserPassword> UserPasswords { get; set; }
    public DbSet<MinuteRecord> TimeMinutes { get; set; }
    public DbSet<OAuth> OAuths { get; set; }
    public DbSet<UserAccessLog> UserAccessLogs { get; set; }

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