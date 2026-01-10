using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimePeriodEntityConfiguration : IEntityTypeConfiguration<TimePeriodEntity>
{
    public void Configure(EntityTypeBuilder<TimePeriodEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Start).IsRequired();
        builder.Property(e => e.End).IsRequired();

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.TimeRecordId).IsRequired();
        builder.Property(e => e.TimerSessionId);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.TimeRecord)
            .WithMany(e => e.TimePeriods)
            .HasForeignKey(e => e.TimeRecordId);

        builder.HasOne<TimerSessionEntity>(e => e.TimerSession)
            .WithMany(e => e.TimePeriods)
            .HasForeignKey(e => e.TimerSessionId);
    }
}