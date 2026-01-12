using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database.Configurations;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Infrastructure.Database;

public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Period> PeriodRecords { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RecordMeta> RecordMetas { get; set; }
    public DbSet<Session> RecordSessions { get; set; }
    public DbSet<ConfirmCode> ConfirmCodes { get; set; }
    public DbSet<UserPassword> UserPasswords { get; set; }
    public DbSet<Minute> MinuteRecords { get; set; }
    public DbSet<OAuth> OAuths { get; set; }
    public DbSet<UserAccessLog> UserAccessLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserEntityConfiguration());
        mb.ApplyConfiguration(new RecordEntityConfiguration());
        mb.ApplyConfiguration(new TimePeriodEntityConfiguration());
        mb.ApplyConfiguration(new CategoryEntityConfiguration());
        mb.ApplyConfiguration(new RecordMetaEntityConfiguration());
        mb.ApplyConfiguration(new TimerSessionEntityConfiguration());
        mb.ApplyConfiguration(new ConfirmCodeEntityConfiguration());
        mb.ApplyConfiguration(new UserPasswordEntityConfiguration());
        mb.ApplyConfiguration(new TimeMinuteEntityConfiguration());
        mb.ApplyConfiguration(new OAuthEntityConfiguration());
        mb.ApplyConfiguration(new UserAccessLogEntityConfiguration());
    }
}