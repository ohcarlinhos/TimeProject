using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimeRecordMetaEntityConfiguration : IEntityTypeConfiguration<TimeRecordMetaEntity>
{
    public void Configure(EntityTypeBuilder<TimeRecordMetaEntity> builder)
    {
        builder.HasKey(e => e.TimeRecordId);

        builder.Property(e => e.TimeRecordId).IsRequired();
        builder.Property(e => e.FormattedTime).HasMaxLength(24);
        builder.Property(e => e.TimeOnSeconds);
        builder.Property(e => e.TimeCount);
        builder.Property(e => e.LastTimeDate);
        builder.Property(e => e.LastTimeDate);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<TimeRecordEntity>().WithOne(e => e.Meta)
            .HasForeignKey<TimeRecordMetaEntity>(e => e.TimeRecordId);
    }
}