using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class ConfirmCodeEntityConfiguration : IEntityTypeConfiguration<ConfirmCode>
{
    public void Configure(EntityTypeBuilder<ConfirmCode> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(36).IsRequired();
        builder.Property(e => e.ExpireDate).IsRequired();
        builder.Property(e => e.IsUsed).IsRequired();
        builder.Property(e => e.WasSent).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Type).IsRequired();

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<User>(e => e.User).WithMany().HasForeignKey(e => e.UserId);
    }
}