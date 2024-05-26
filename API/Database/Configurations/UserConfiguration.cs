using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<Entities.User>
{
    public void Configure(EntityTypeBuilder<Entities.User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Email).IsUnique();
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Name).HasMaxLength(120).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(64).IsRequired();
        builder.Property(e => e.Password).HasMaxLength(72).IsRequired();
        builder.Property(e => e.UserRole).IsRequired();
        
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();    
    }
}