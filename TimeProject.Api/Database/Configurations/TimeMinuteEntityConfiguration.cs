using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Database.Configurations;

public class TimeMinuteEntityConfiguration : IEntityTypeConfiguration<TimeMinuteEntity>
{
    public void Configure(EntityTypeBuilder<TimeMinuteEntity> builder)
    {
        builder.ToTable("time_minutes");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.TimeRecordId).IsRequired();
        builder.Property(e => e.Minutes);
        builder.Property(e => e.Date);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne<TimeRecordEntity>(e => e.TimeRecord)
            .WithMany()
            .HasForeignKey(e => e.TimeRecordId);
    }
}