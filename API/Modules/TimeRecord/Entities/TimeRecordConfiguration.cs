using API.Modules.Category.Entities;
using API.Modules.TimePeriod.Entities;
using API.Modules.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Modules.TimeRecord.Entities;

public class TimeRecordConfiguration: IEntityTypeConfiguration<TimeRecord>
{
    public void Configure(EntityTypeBuilder<TimeRecord> builder)
    {
        builder.ToTable("time_records");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Description).HasMaxLength(120);
        
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.CategoryId);
        
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired();
        
        builder.HasOne<User.Entities.User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne<CategoryEntity>().WithMany().HasForeignKey(e => e.CategoryId);
        builder.HasMany<TimePeriodEntity>(e => e.TimePeriods).WithOne();
    }
}