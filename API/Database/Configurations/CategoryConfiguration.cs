using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Entities.Category>
{
    public void Configure(EntityTypeBuilder<Entities.Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
        
        builder.Property(e => e.UserId).IsRequired();
        
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired();
        
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
    }
}