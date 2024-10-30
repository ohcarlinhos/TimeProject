using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database.Configurations;

public class TimeRecordConfiguration : IEntityTypeConfiguration<TimeRecordEntity>
{
    public void Configure(EntityTypeBuilder<TimeRecordEntity> builder)
    {
        builder.ToTable("time_records");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Title).HasMaxLength(120);
        builder.Property(e => e.Description).HasMaxLength(240);
        builder.Property(e => e.ExternalLink).HasMaxLength(120);

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.CategoryId);
        builder.Property(e => e.Code).HasMaxLength(36);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.TimePeriods).WithOne(e => e.TimeRecord);
    }
}