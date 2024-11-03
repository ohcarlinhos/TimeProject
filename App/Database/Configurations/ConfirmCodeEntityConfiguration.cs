using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database.Configurations;

public class ConfirmCodeEntityConfiguration : IEntityTypeConfiguration<ConfirmCodeEntity>
{
    public void Configure(EntityTypeBuilder<ConfirmCodeEntity> builder)
    {
        builder.ToTable("confirm_codes");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(36).IsRequired();
        builder.Property(e => e.ExpireDate).IsRequired();
        builder.Property(e => e.IsUsed).IsRequired();
        builder.Property(e => e.WasSent).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Type).IsRequired();

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>(e => e.User).WithMany().HasForeignKey(e => e.UserId);
    }
}