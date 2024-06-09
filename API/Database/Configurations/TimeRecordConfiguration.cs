using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations;

public class TimeRecordConfiguration : IEntityTypeConfiguration<Entities.TimeRecord>
{
    public void Configure(EntityTypeBuilder<Entities.TimeRecord> builder)
    {
        builder.ToTable("time_records");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Description).HasMaxLength(120);

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.CategoryId);
        builder.Property(e => e.Code).HasMaxLength(32); 

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<Entities.User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.TimePeriods).WithOne(e => e.TimeRecord);
    }
}