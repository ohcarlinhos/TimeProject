using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class TimeMinuteEntityConfiguration : IEntityTypeConfiguration<MinuteRecord>
{
    public void Configure(EntityTypeBuilder<MinuteRecord> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.RecordId).IsRequired();
        builder.Property(e => e.Minutes);
        builder.Property(e => e.Date);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne<Record>(e => e.Record)
            .WithMany()
            .HasForeignKey(e => e.RecordId);
    }
}