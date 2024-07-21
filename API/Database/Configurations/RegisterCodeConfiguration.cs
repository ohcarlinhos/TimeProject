using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations;

public class RegisterCodeConfiguration : IEntityTypeConfiguration<RegisterCode>
{
    public void Configure(EntityTypeBuilder<RegisterCode> builder)
    {
        builder.ToTable("register_code");
        builder.HasKey(e => e.Key);

        builder.Property(e => e.Key).IsRequired();
        builder.Property(e => e.IsUsed).IsRequired();
        builder.Property(e => e.UserId);

        builder.HasOne<User>().WithOne().HasForeignKey<RegisterCode>(e => e.UserId);
    }
}