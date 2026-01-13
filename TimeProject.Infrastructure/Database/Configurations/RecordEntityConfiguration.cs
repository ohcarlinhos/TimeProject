using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class RecordEntityConfiguration : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
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

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.Periods).WithOne(e => e.Record);
    }
}