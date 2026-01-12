using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimerSessionEntityConfiguration : IEntityTypeConfiguration<RecordSession>
{
    public void Configure(EntityTypeBuilder<RecordSession> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.RecordId).IsRequired();
        builder.Property(e => e.Type).HasMaxLength(10);
        builder.Property(e => e.From).HasMaxLength(15);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne<Record>(e => e.Record)
            .WithMany()
            .HasForeignKey(e => e.RecordId);

        builder.HasMany(e => e.PeriodRecords)
            .WithOne(e => e.TimerSession)
            .HasForeignKey(e => e.TimerSessionId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}