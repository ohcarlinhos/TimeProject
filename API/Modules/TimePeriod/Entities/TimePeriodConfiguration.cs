using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Modules.TimePeriod.Entities;

public class TimePeriodConfiguration : IEntityTypeConfiguration<TimePeriod>
{
    public void Configure(EntityTypeBuilder<TimePeriod> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Start).IsRequired();
        builder.Property(e => e.End).IsRequired();

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.TimeRecordId).IsRequired();

        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired();

        builder.HasOne<User.Entities.User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.TimeRecord).WithMany(e => e.TimePeriods)
            .HasForeignKey(e => e.TimeRecordId);
    }
}