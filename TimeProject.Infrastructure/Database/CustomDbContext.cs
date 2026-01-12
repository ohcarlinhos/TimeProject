using Microsoft.EntityFrameworkCore;
using TimeProject.Infrastructure.Database.Configurations;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Database;

public class CustomDbContext(DbContextOptions<CustomDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RecordMeta> RecordMetas { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<ConfirmCode> ConfirmCodes { get; set; }
    public DbSet<UserPassword> UserPasswords { get; set; }
    public DbSet<Minute> Minutes { get; set; }
    public DbSet<OAuth> OAuths { get; set; }
    public DbSet<UserAccessLog> UserAccessLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new UserEntityConfiguration());
        mb.ApplyConfiguration(new RecordEntityConfiguration());
        mb.ApplyConfiguration(new PeriodEntityConfiguration());
        mb.ApplyConfiguration(new CategoryEntityConfiguration());
        mb.ApplyConfiguration(new RecordMetaEntityConfiguration());
        mb.ApplyConfiguration(new SessionEntityConfiguration());
        mb.ApplyConfiguration(new ConfirmCodeEntityConfiguration());
        mb.ApplyConfiguration(new UserPasswordEntityConfiguration());
        mb.ApplyConfiguration(new MinuteEntityConfiguration());
        mb.ApplyConfiguration(new OAuthEntityConfiguration());
        mb.ApplyConfiguration(new UserAccessLogEntityConfiguration());
    }
}