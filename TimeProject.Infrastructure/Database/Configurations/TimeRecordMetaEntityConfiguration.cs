using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimeRecordMetaEntityConfiguration : IEntityTypeConfiguration<RecordMeta>
{
    public void Configure(EntityTypeBuilder<RecordMeta> builder)
    {
        builder.HasKey(e => e.RecordId);

        builder.Property(e => e.RecordId).IsRequired();
        builder.Property(e => e.FormattedTime).HasMaxLength(24);
        builder.Property(e => e.TimeOnSeconds);
        builder.Property(e => e.TimeCount);
        builder.Property(e => e.LastTimeDate);
        builder.Property(e => e.LastTimeDate);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<Record>().WithOne(e => e.Meta)
            .HasForeignKey<RecordMeta>(e => e.RecordId);
    }
}