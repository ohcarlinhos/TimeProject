using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database.Configurations;

public class TimerSessionConfiguration : IEntityTypeConfiguration<TimerSessionEntity>
{
    public void Configure(EntityTypeBuilder<TimerSessionEntity> builder)
    {
        builder.ToTable("timer_sessions");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.TimeRecordId).IsRequired();
        builder.Property(e => e.Type).HasMaxLength(10);
        builder.Property(e => e.From).HasMaxLength(15);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);
        
        builder.HasOne<TimeRecordEntity>(e => e.TimeRecordEntity)
            .WithMany()
            .HasForeignKey(e => e.TimeRecordId);
        
        builder.HasMany(e => e.TimePeriods)
            .WithOne(e => e.TimerSession)
            .HasForeignKey(e => e.TimerSessionId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}