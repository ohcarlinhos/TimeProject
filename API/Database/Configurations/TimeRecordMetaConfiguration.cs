using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations;

public class TimeRecordMetaConfiguration : IEntityTypeConfiguration<TimeRecordMeta>
{
    public void Configure(EntityTypeBuilder<TimeRecordMeta> builder)
    {
        builder.ToTable("time_record_metas");
        builder.HasKey(e => e.TimeRecordId);

        builder.Property(e => e.TimeRecordId).IsRequired();
        builder.Property(e => e.FormattedTime).HasMaxLength(24);
        builder.Property(e => e.TimePeriodCount);
        builder.Property(e => e.LastTimePeriodDate);
        builder.Property(e => e.LastTimePeriodDate);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<TimeRecord>().WithOne(e => e.Meta).HasForeignKey<TimeRecordMeta>(e => e.TimeRecordId);
    }
}