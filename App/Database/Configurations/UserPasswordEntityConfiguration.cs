using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Database.Configurations;

public class UserPasswordEntityConfiguration : IEntityTypeConfiguration<UserPasswordEntity>
{
    public void Configure(EntityTypeBuilder<UserPasswordEntity> builder)
    {
        builder.ToTable("user_passwords");
        builder.HasKey(e => e.UserId);
        
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Password).HasMaxLength(48);

        builder.HasOne<UserEntity>().WithOne().HasForeignKey<UserPasswordEntity>(e =>e.UserId);
    }
}