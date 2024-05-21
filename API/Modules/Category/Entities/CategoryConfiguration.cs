using API.Modules.TimeRecord.Entities;
using API.Modules.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Modules.Category.Entities;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
        
        builder.Property(e => e.UserId).IsRequired();
        
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired();
        
        builder.HasOne<User.Entities.User>().WithMany().HasForeignKey(e => e.UserId);
    }
}