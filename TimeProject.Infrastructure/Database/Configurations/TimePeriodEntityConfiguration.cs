using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimePeriodEntityConfiguration : IEntityTypeConfiguration<PeriodRecord>
{
    public void Configure(EntityTypeBuilder<PeriodRecord> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Start).IsRequired();
        builder.Property(e => e.End).IsRequired();

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.RecordId).IsRequired();
        builder.Property(e => e.TimerSessionId);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.Record)
            .WithMany(e => e.PeriodRecords)
            .HasForeignKey(e => e.RecordId);

        builder.HasOne<TimerSession>(e => e.TimerSession)
            .WithMany(e => e.PeriodRecords)
            .HasForeignKey(e => e.TimerSessionId);
    }
}