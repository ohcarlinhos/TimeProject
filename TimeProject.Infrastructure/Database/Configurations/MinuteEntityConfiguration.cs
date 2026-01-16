using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class MinuteEntityConfiguration : IEntityTypeConfiguration<Minute>
{
    public void Configure(EntityTypeBuilder<Minute> builder)
    {
        builder.HasKey(e => e.MinuteId);

        builder.Property(e => e.MinuteId).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.RecordId).IsRequired();
        builder.Property(e => e.Total);
        builder.Property(e => e.Date);

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);

        builder.HasOne<Record>(e => e.Record).WithMany().HasForeignKey(e => e.RecordId);
    }
}