using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database.Configurations;

public class RegisterCodeEntityConfiguration : IEntityTypeConfiguration<RegisterCodeEntity>
{
    public void Configure(EntityTypeBuilder<RegisterCodeEntity> builder)
    {
        builder.ToTable("register_code");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.IsUsed).IsRequired();
        builder.Property(e => e.UserId);

        builder.HasOne<UserEntity>(e => e.User).WithOne()
            .HasForeignKey<RegisterCodeEntity>(e => e.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}