using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Database.Configurations;

public class UserPasswordEntityConfiguration : IEntityTypeConfiguration<UserPasswordEntity>
{
    public void Configure(EntityTypeBuilder<UserPasswordEntity> builder)
    {
        builder.ToTable("user_passwords");
        builder.HasKey(e => e.UserId);

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Password).HasMaxLength(72).IsRequired();

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithOne().HasForeignKey<UserPasswordEntity>(e => e.UserId);
    }
}